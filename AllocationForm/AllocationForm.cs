using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace AllocationForm
{
    public partial class Allocation : Form
    {
        public Allocation()
        {
            InitializeComponent();
        }

        private void loadAllocationFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Select Allocation sheet";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "csv";
            // "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourcePathTextBox.Text = openFileDialog1.FileName;
            }

        }

        private void loadLookupSheetButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.InitialDirectory = @"C:\";
            openFileDialog2.Title = "Select Styles Selling sheet";

            openFileDialog2.CheckFileExists = true;
            openFileDialog2.CheckPathExists = true;

            openFileDialog2.DefaultExt = "csv";
            openFileDialog2.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog2.RestoreDirectory = true;

            openFileDialog2.ReadOnlyChecked = true;
            openFileDialog2.ShowReadOnly = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                styleLookupPathTextBox.Text = openFileDialog2.FileName;
            }
        }

        private void loadStyleMasterSheetButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog();

            openFileDialog3.InitialDirectory = @"C:\";
            openFileDialog3.Title = "Select Styles Master sheet";

            openFileDialog3.CheckFileExists = true;
            openFileDialog3.CheckPathExists = true;

            openFileDialog3.DefaultExt = "csv";
            openFileDialog3.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog3.RestoreDirectory = true;

            openFileDialog3.ReadOnlyChecked = true;
            openFileDialog3.ShowReadOnly = true;

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                styleMasterPathTextBox.Text = openFileDialog3.FileName;
            }
        }


        private void selectOutputFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            outputPathTextBox.Text = fbd.SelectedPath;
        }





        private void runApp_Click(object sender, EventArgs e)
        {
            try
            {
                // check that none of the inputs are null or empty
                if (outputFileNameTextBox == null || String.IsNullOrEmpty(outputFileNameTextBox.Text))
                {
                    throw new AllocationException("Please input a file name for the output file.");
                }
                if (sourcePathTextBox == null || String.IsNullOrEmpty(sourcePathTextBox.Text))
                {
                    throw new AllocationException("Please input the source file.");
                }
                if (styleLookupPathTextBox == null || String.IsNullOrEmpty(styleLookupPathTextBox.Text))
                {
                    throw new AllocationException("Please input the style selling file.");
                }
                if (styleMasterPathTextBox == null || String.IsNullOrEmpty(styleMasterPathTextBox.Text))
                {
                    throw new AllocationException("Please input the style master file.");
                }


                var sourcePath = sourcePathTextBox.Text; // this is a path
                var lookupPath = styleLookupPathTextBox.Text; // this is a path
                var styleMasterPath = styleMasterPathTextBox.Text; // this is a path
                var outputDirectory = outputPathTextBox.Text; // this is a folder location
                var outputPath = Path.Combine(outputDirectory, outputFileNameTextBox.Text + ".csv"); // output

                // make sure the input files are .csv format
                if (Path.GetExtension(sourcePath) != ".csv" || Path.GetExtension(lookupPath) != ".csv")
                {
                    throw new AllocationException("You may only input csv files into the input.");
                }
                if (!differentBrandRadioButton.Checked && !brandRadioButton.Checked) // No radio buttons are checked
                {
                    throw new AllocationException("Please select a store.");
                }
    



                var delimiter = ",";
                var lineNumber = 0;
                var maxColumnWidth = 0;
                int storeNumber = 0;


                var columnNumbersToKeep = new List<int>(); // index of columns of data to keep in the new sheet (ignoring headers)
                columnNumbersToKeep.Add(0);



                // store key-value pairs
                var storeList = new List<Tuple<int, string, int, int>>(); // store number, store name, WTD U column number, OH column number
                storeList.Add(new Tuple<int, string, int, int>(1, "Store 1", 13, 16));
                storeList.Add(new Tuple<int, string, int, int>(2, "Store 2", 20, 23));
                storeList.Add(new Tuple<int, string, int, int>(3, "Store 3", 27, 30));
                storeList.Add(new Tuple<int, string, int, int>(4, "Store 4", 24, 37));
                storeList.Add(new Tuple<int, string, int, int>(5, "Store 5", 41, 44));
                storeList.Add(new Tuple<int, string, int, int>(6, "Store 6", 48, 51));
                storeList.Add(new Tuple<int, string, int, int>(7, "Store 7", 55, 58));
                storeList.Add(new Tuple<int, string, int, int>(8, "Store 8", 62, 65));
                storeList.Add(new Tuple<int, string, int, int>(9, "Store 9", 69, 72));
                storeList.Add(new Tuple<int, string, int, int>(10, "Store 10", 76, 79));
                storeList.Add(new Tuple<int, string, int, int>(11, "Store 11", 83, 86));
                storeList.Add(new Tuple<int, string, int, int>(13, "Store 13", 90, 93)); // no 12?
                storeList.Add(new Tuple<int, string, int, int>(201, "Different Store 1", 13, 16)); 
                storeList.Add(new Tuple<int, string, int, int>(202, "Different Store 2", 20, 23));

                var checkedButton = storeSelectGroupBox.Controls.OfType<RadioButton>() // find type of sheet we have, to determine column numbers of store 300
                                      .FirstOrDefault(r => r.Checked);
                if (checkedButton.Text.Equals("First Brand"))
                {
                    storeList.Add(new Tuple<int, string, int, int>(300, "ALL STORES", 97, 100)); // 999 = store 300 = bulk Store
                }
                else if (checkedButton.Text.Equals("Other Brand"))
                {
                    storeList.Add(new Tuple<int, string, int, int>(300, "ALL STORES", 27, 30)); // 999 = store 300 = bulk Different Store
                }



                var splitExpression = new Regex(@"(" + delimiter + @")(?=(?:[^""]|""[^""]*"")*$)");



                using (var writer = new StreamWriter(outputPath))
                using (var reader = new StreamReader(sourcePath))
                {
                    string line = null;
                    bool columnNumbersToKeepSet = false;
                    //string[] linesToSearch = File.ReadAllLines(lookupPath); // load lookup sheet into memory
                    string[] StyleMasterToSearch = File.ReadAllLines(styleMasterPath); // load lookup sheet into memory



                    var sourcePathLength = File.ReadAllLines(sourcePath).Length;
                    progressBar.Maximum = sourcePathLength;
                    progressBar.Step = (int) Math.Ceiling((double) sourcePathLength / 100);
                    progressBar.Value = 0;


                    



                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;

                        var columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();
                        if (columns.Length > maxColumnWidth)
                        {
                            maxColumnWidth = columns.Length;
                        }

                        //if (columns.Length < maxColumnWidth)
                        //{
                        //    StringBuilder templine = new StringBuilder();
                        //    templine.Append(line);
                        //    while (columns.Length < maxColumnWidth) // current column width < max column width 
                        //    {
                        //        templine.Append(reader.ReadLine());
                        //        string newColumnString = templine.ToString();
                        //        columns = splitExpression.Split(newColumnString).Where(s => s != delimiter).ToArray();
                        //    }
                        //    if (columns.Length > maxColumnWidth)
                        //    {
                        //        Console.WriteLine("Column Number " + lineNumber + " too long");
                        //    }
                        //}








                        // prevent out of range exceptions by checking column length first
                        if (columns.Length > 1)
                        {

                            if (columns[1].Equals("Customer"))
                            {
                                storeNumber = 0; // reset store number variable
                                writer.WriteLine(line); // write line of customer
                                lineNumber++;
                                line = reader.ReadLine(); // orderno line, breaks in middle due to memo's enter spaces
                                columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();
                                if (columns.Length > 13)
                                {
                                    Int32.TryParse(columns[13], out storeNumber);
                                }

                                while (columns.Length == 1 || !(columns[1].Equals("D Sts"))) // write all lines until you hit "D Sts" column
                                {
                                    writer.WriteLine(line);
                                    lineNumber++;
                                    line = reader.ReadLine();
                                    columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();
                                    if (storeNumber == 0 && columns.Length > 13) // store number not set and column index in bounds
                                    {
                                        Int32.TryParse(columns[13], out storeNumber);
                                    }
                                }

                                Console.WriteLine("Store Number: " + storeNumber);

                            }

                            if (!columnNumbersToKeepSet && columns[1].Equals("D Sts")) // column headers tell us the columns we wish to keep. Set the first time we encounter "D Sts"
                            {
                                for (int i = 0; i < columns.Length; i++)
                                {
                                    if (!(String.IsNullOrEmpty(columns[i]) || columns[i].Equals(" ")))
                                    {
                                        columnNumbersToKeep.Add(i);
                                    }
                                }

                                columnNumbersToKeepSet = true;
                            }
                            if (columns[1].Equals("D Sts")) // column headers tell us the columns we wish to keep
                            {
                                List<string> condensedColumns = new List<string>();
                                foreach (int index in columnNumbersToKeep)
                                {
                                    condensedColumns.Add(columns[index]);
                                }

                                condensedColumns.Insert(2, "WTD U");
                                condensedColumns.Insert(3, "OH");
                                condensedColumns.Insert(4, "Description");

                                string[] condensedColumnsArray = condensedColumns.ToArray();

                                writer.WriteLine(string.Join(delimiter, condensedColumnsArray)); // write the columns without the extra spaces


                                line = reader.ReadLine();
                                columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();
                                while (columns[1].Equals("Open"))
                                {
                                    lineNumber++;
                                    string styleToSearch = columns[3];
                                    string colorToSearch = columns[6];
                                    string resultWTD = "Not found";
                                    string resultOH = "Not found";
                                    string resultDescript = "Not found";

                                    TextFieldParser linesToSearch = new TextFieldParser(lookupPath);
                                    linesToSearch.HasFieldsEnclosedInQuotes = true;
                                    linesToSearch.SetDelimiters(",");

                                    while(!linesToSearch.EndOfData)
                                    {
                                        // find item description in style_master sheet
                                        string styleDescriptSearchResult = StyleMasterToSearch.Where(style => style.Contains(styleToSearch + ",")).FirstOrDefault(); // StyleMasterToSearch[10] = "0042J-JJ1068,ANCHOR PANT"
                                        resultDescript = styleDescriptSearchResult.Split(new char[] { ',' }, 2)[1]; // split on first comma to 2 substrings, take the second

                                        // find WTD_U and OH entries -- might not always find a result
                                        var searchColumns = linesToSearch.ReadFields();
                                        if (searchColumns[8].Equals(styleToSearch) && searchColumns[10].Equals(colorToSearch)) // lookup styles in lookupPath sheet
                                        {
                                            foreach (var store in storeList) // need to find corresponding entry of storeList to get relevant columns of WTD and OH values
                                            {
                                                if (store.Item1.Equals(storeNumber))
                                                {
                                                    resultWTD = searchColumns[store.Item3]; // Item3 is WTD column
                                                    resultOH = searchColumns[store.Item4]; // Item4 is OH column
                                                    
                                                }
                                            }

                                            break; // break out of search
                                        }
                                    }

                                    linesToSearch.Close();

                                    //foreach (var linesearch in linesToSearch)
                                    //{
                                    //    var searchColumns = splitExpression.Split(linesearch).Where(s => s != delimiter).ToArray();
                                    //    if (searchColumns[8].Equals(styleToSearch) && searchColumns[10].Equals(colorToSearch)) // lookup styles in lookupPath sheet
                                    //    {
                                    //        foreach (var store in storeList) // need to find corresponding entry of storeList to get relevant columns of WTD and OH values
                                    //        {
                                    //            if (store.Item1.Equals(storeNumber))
                                    //            {
                                    //                resultWTD = searchColumns[store.Item3]; // Item3 is WTD column
                                    //                resultOH = searchColumns[store.Item4]; // Item4 is OH column
                                    //                string styleDescriptSearchResult = StyleMasterToSearch.Where(style => style.Contains(styleToSearch + ",")).FirstOrDefault(); // StyleMasterToSearch[10] = "0042J-JJ1068,ANCHOR PANT"
                                    //                resultDescript = styleDescriptSearchResult.Split(new char[] { ',' }, 2)[1]; // split on first comma to 2 substrings, take the second
                                    //            }
                                    //        }

                                    //        break; // break out of search
                                    //    }
                                    //}


                                    //var values = linesToSearch.Select(lookupline => lookupline.Split(',')).ToList();

                                    //// searchResult is a string array containing the matching line 
                                    //var searchResult = values.Where(x => x[8].Equals(styleToSearch) && x[10].Equals(colorToSearch)).Select(x => x).FirstOrDefault();

                                    //if (searchResult != null && searchResult.Length > 10) // cehck search result looks correct
                                    //{
                                    //    foreach (var store in storeList) // need to find corresponding entry of storeList to get relevant columns of WTD and OH values
                                    //    {
                                    //        if (store.Item1.Equals(storeNumber))
                                    //        {
                                    //            resultWTD = searchResult[store.Item3]; // Item3 is WTD column
                                    //            resultOH = searchResult[store.Item4]; // Item4 is OH column
                                    //            resultDescript = searchResult[9]; // column 9 is item description
                                    //        }
                                    //    }
                                    //}


                                    //// splitExpression.Split(lookupline).Where(s => s != delimiter)
                                    //var values = linesToSearch.ReadFields();

                                    //// searchResult is a string array containing the matching line 
                                    //var searchResult = values.Where(x => x[8].Equals(styleToSearch) && x[10].Equals(colorToSearch)).Select(x => x).FirstOrDefault();

                                    //if (searchResult != null && searchResult.Length > 10) // check search result looks correct
                                    //{
                                    //    foreach (var store in storeList) // need to find corresponding entry of storeList to get relevant columns of WTD and OH values
                                    //    {
                                    //        if (store.Item1.Equals(storeNumber))
                                    //        {
                                    //            resultWTD = searchResult[store.Item3].ToString(); // Item3 is WTD column
                                    //            resultOH = searchResult[store.Item4].ToString(); // Item4 is OH column
                                    //            resultDescript = searchResult[9].ToString(); // column 9 is item description
                                    //        }
                                    //    }
                                    //}




                                    //var searchColumns = splitExpression.Split(searchResult).Where(s => s != delimiter).ToArray();

                                    //foreach (var linesearch in linesToSearch)
                                    //{
                                    //    var searchColumns = splitExpression.Split(linesearch).Where(s => s != delimiter).ToArray();
                                    //    if (searchColumns[8].Equals(styleToSearch) && searchColumns[10].Equals(colorToSearch)) // lookup styles in lookupPath sheet
                                    //    {
                                    //        foreach (var store in storeList) // need to find corresponding entry of storeList to get relevant columns of WTD and OH values
                                    //        {
                                    //            if (store.Item1.Equals(storeNumber))
                                    //            {
                                    //                resultWTD = searchColumns[store.Item3]; // Item3 is WTD column
                                    //                resultOH = searchColumns[store.Item4]; // Item4 is OH column
                                    //                resultDescript = searchColumns[9]; // column 9 is item description
                                    //            }
                                    //        }

                                    //        break; // break out of search
                                    //    }
                                    //}







                                    List<string> condensedColumnsOpen = new List<string>();
                                    foreach (int index in columnNumbersToKeep)
                                    {
                                        condensedColumnsOpen.Add(columns[index]);
                                    }

                                    condensedColumnsOpen.Insert(2, resultWTD);
                                    condensedColumnsOpen.Insert(3, resultOH);
                                    condensedColumnsOpen.Insert(4, resultDescript);

                                    string[] condensedColumnsArrayOpen = condensedColumnsOpen.ToArray();

                                    writer.WriteLine(string.Join(delimiter, condensedColumnsArrayOpen)); // write the columns without the extra spaces

                                    lineNumber++;
                                    line = reader.ReadLine();
                                    columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();



                                }
                                lineNumber++;
                                writer.WriteLine(line); // write final line after last "Open"
                            }


                            // TODO: search and replace in columns
                            // example: replace 'v' in the first column with '\/': if (columns[0].Contains("v")) columns[0] = columns[0].Replace("v", @"\/");

                        }
                        progressBar.PerformStep();

                    } // end while loop


                }


                
                // program over
                progressBar.Value = progressBar.Maximum;
                MessageBox.Show("File: " + outputPath + " has been created.", "Output complete");
            }
            catch (AllocationException ae)
            {
                MessageBox.Show(ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        


    }
}
