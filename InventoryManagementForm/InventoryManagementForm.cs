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
using System.Globalization;

namespace InventoryManagementForm
{
    public partial class InventoryManagement : Form
    {
        public InventoryManagement()
        {
            InitializeComponent();
        }

        private void loadStyleSellingFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Select Styles Selling sheet";

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

        private void loadInventoryLookupSheetButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.InitialDirectory = @"C:\";
            openFileDialog2.Title = "Select Inventory sheet";

            openFileDialog2.CheckFileExists = true;
            openFileDialog2.CheckPathExists = true;

            openFileDialog2.DefaultExt = "csv";
            openFileDialog2.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog2.RestoreDirectory = true;

            openFileDialog2.ReadOnlyChecked = true;
            openFileDialog2.ShowReadOnly = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                inventoryLookupPathTextBox.Text = openFileDialog2.FileName;
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
                if (outputStyleFileNameTextBox == null || String.IsNullOrEmpty(outputStyleFileNameTextBox.Text))
                {
                    throw new InventoryManagementException("Please input a file name for the styles output file.");
                }
                if (outputInventoryFileNameTextBox == null || String.IsNullOrEmpty(outputInventoryFileNameTextBox.Text))
                {
                    throw new InventoryManagementException("Please input a file name for the inventory output file.");
                }
                if (sourcePathTextBox == null || String.IsNullOrEmpty(sourcePathTextBox.Text))
                {
                    throw new InventoryManagementException("Please input the style selling file.");
                }
                if (inventoryLookupPathTextBox == null || String.IsNullOrEmpty(inventoryLookupPathTextBox.Text))
                {
                    throw new InventoryManagementException("Please input the inventory file.");
                }

                int topSellingStylesFilterPercentage;
                if (minSTPercentageTextBox == null || String.IsNullOrEmpty(minSTPercentageTextBox.Text) || !Int32.TryParse(minSTPercentageTextBox.Text, out topSellingStylesFilterPercentage))
                {
                    throw new InventoryManagementException("Please input an integer for min S/T%.");
                }

                double givenBudget;
                if (transferBudgetTextBox == null || String.IsNullOrEmpty(transferBudgetTextBox.Text) || !Double.TryParse(transferBudgetTextBox.Text, out givenBudget))
                {
                    throw new InventoryManagementException("Please input a decimal value for the transfer budget.");
                }

                int numOfOHUnits;
                if (minNumOHUnitsTextBox == null || String.IsNullOrEmpty(minNumOHUnitsTextBox.Text) || !Int32.TryParse(minNumOHUnitsTextBox.Text, out numOfOHUnits))
                {
                    throw new InventoryManagementException("Please input an integer for min number of OH units.");
                }
                if (seasonCodeTextBox == null || String.IsNullOrEmpty(seasonCodeTextBox.Text))
                {
                    throw new InventoryManagementException("Please input season codes to include.");
                }
                string seasonCodeTextBoxNoSpaces = seasonCodeTextBox.Text.Replace(" ", String.Empty);
                string[] seasonCodeStringArray = seasonCodeTextBoxNoSpaces.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> seasonCodes = new List<string>();

                foreach (var seasonCodeString in seasonCodeStringArray)
                {
                    int seasonCode = 0;

                    if (Int32.TryParse(seasonCodeString, out seasonCode)) // check that the user entered an integer
                    {
                        seasonCodes.Add(seasonCodeString); // if so, add to the list of season codes 
                    }
                    else
                    {
                        throw new InventoryManagementException("Please input an integer value for the season code. \"" + seasonCodeString + "\" is not an integer."); // otherwise, give an error message
                    }
                }
                



                var sourcePath = sourcePathTextBox.Text; // this is a path - style_selling
                var inventoryPath = inventoryLookupPathTextBox.Text; // this is a path - updated_inventory

                var tempPath = Path.GetTempFileName(); // temporary file for sorting the data

                var outputDirectory = outputPathTextBox.Text; // this is a folder location
                var outputPath = Path.Combine(outputDirectory, outputStyleFileNameTextBox.Text + ".csv"); // output styles.csv
                var inventoryOutputPath = Path.Combine(outputDirectory, outputInventoryFileNameTextBox.Text + ".csv"); // output stylesOH.csv

                // make sure the input files are .csv format
                if (Path.GetExtension(sourcePath) != ".csv" || Path.GetExtension(inventoryPath) != ".csv")
                {
                    throw new InventoryManagementException("You may only input csv files into the input.");
                }


                // store key-value pairs
                var storeList = new List<Tuple<int, string, int>>(); // store number, store name, OH column number
                storeList.Add(new Tuple<int, string, int>(1, "Store 1", 16));
                storeList.Add(new Tuple<int, string, int>(2, "Store 2", 23));
                storeList.Add(new Tuple<int, string, int>(3, "Store 3", 30));
                storeList.Add(new Tuple<int, string, int>(4, "Store 4", 37));
                storeList.Add(new Tuple<int, string, int>(5, "Store 5", 44));
                storeList.Add(new Tuple<int, string, int>(6, "Store 6", 51));
                storeList.Add(new Tuple<int, string, int>(7, "Store 7", 58));
                storeList.Add(new Tuple<int, string, int>(8, "Store 8", 65));
                storeList.Add(new Tuple<int, string, int>(9, "Store 9", 72));
                storeList.Add(new Tuple<int, string, int>(10, "Store 10", 79));
                storeList.Add(new Tuple<int, string, int>(11, "Store 11", 86));
                storeList.Add(new Tuple<int, string, int>(13, "Store 13", 93)); // no 12?


                

                CultureInfo ci = new CultureInfo("en-US");
                double runningBudgetTotal = 0;

                
                var delimiter = ",";
                var firstLineContainsHeaders = true;
                var secondLineContainsHeaders = true;
                var lineNumber = 0;
                int[] columnIndex = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 100, 103, 119 }; // columns to keep in output csv
                int[] columnIndexInventory = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; // columns to keep in output inventory csv


                var lookupCodesOutput = new List<string>(); // lookup code (column A)
                var listOfRetailPrices = new List<string>(); // RetailPrice (column M of source)

                

                var splitExpression = new Regex(@"(" + delimiter + @")(?=(?:[^""]|""[^""]*"")*$)");

                // first, let's sort the spreadsheet by the column of top selling styles
                string[] unsortedLines = File.ReadAllLines(sourcePath);
                var data = unsortedLines.Skip(2); // 2 lines of headers, we skip these in the sort



                var sorted = data.Select(line => new
                {
                    SortKey = Int32.Parse((splitExpression.Split(line).Where(s => s != delimiter).ToArray()[103]).TrimEnd('%')),
                    Line = line
                })
                .OrderByDescending(x => x.SortKey)
                .Select(x => x.Line);
                File.WriteAllLines(tempPath, unsortedLines.Take(2).Concat(sorted));


                using (var writer = new StreamWriter(outputPath))
                using (var reader = new StreamReader(tempPath))
                {
                    string line = null;
                    string[] headers = null;
                    if (firstLineContainsHeaders)
                    {
                        line = reader.ReadLine();
                        lineNumber++;

                        if (string.IsNullOrEmpty(line)) return; // file is empty;

                        headers = splitExpression.Split(line).Where(s => s != delimiter).ToArray();

                        //writer.WriteLine(line); // write the original header to the temp file.
                    }

                    if (secondLineContainsHeaders)
                    {
                        line = reader.ReadLine();
                        lineNumber++;

                        headers = splitExpression.Split(line).Where(s => s != delimiter).ToArray();
                        List<string> newHeaderList = new List<string>();

                        foreach (int index in columnIndex)
                        {
                            newHeaderList.Add(headers[index]); // add column header in specified index range
                        }

                        newHeaderList.Insert(1, "Store Name"); // add header for the list of store names

                        string[] newHeaderArray = newHeaderList.ToArray();



                        writer.WriteLine(string.Join(delimiter, newHeaderArray)); // write the original header to the temp file.
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;

                        var columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();

                        // if there are no headers, do a simple sanity check to make sure you always have the same number of columns in a line
                        if (headers == null)
                        {
                            headers = new string[columns.Length];
                        }

                        if (columns.Length != headers.Length)
                        {
                            throw new InvalidOperationException(string.Format("Line {0} is missing one or more columns.", lineNumber));
                        }

                        // TODO: search and replace in columns
                        // example: replace 'v' in the first column with '\/': if (columns[0].Contains("v")) columns[0] = columns[0].Replace("v", @"\/");

                        NumberStyles styles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                        String columnPercentageLTDSTString = columns[103].TrimEnd('%');
                        int columnPercentageLTDST = 0;

                        //String columnBudgetString = columns[119].Replace("\"", ""); // column DP has double quotes around the dollar amount, remove them
                        //double columnBudget = 0;
                        String retailPriceString = columns[12];
                        double retailPrice = 0;
                        Double.TryParse(retailPriceString, styles, ci.NumberFormat, out retailPrice);

                        if (seasonCodes.Any(columns[6].Contains)) // check season code column "Delivery" to see if it matches any of the season codes the user entered
                        {
                            foreach (var ohColumn in storeList)
                            {
                                String columnofOHunitsString = columns[ohColumn.Item3]; // OH for a given store
                                int columnofOHunits = 0;


                                bool parsed = Int32.TryParse(columnPercentageLTDSTString, styles, ci.NumberFormat, out columnPercentageLTDST) &&
                                    Int32.TryParse(columnofOHunitsString, styles, ci.NumberFormat, out columnofOHunits);


                                // check our given constraints 
                                if (parsed && columnPercentageLTDST > topSellingStylesFilterPercentage // check we are above the filter percentage
                                    && columnofOHunits > numOfOHUnits // check we are above the #units specified (column CW)
                                    && givenBudget > runningBudgetTotal) // check we do not exceed the given budget (more than once-- total updated inside if block)
                                {
                                    // save the lookup code to a separate list
                                    lookupCodesOutput.Add(columns[0] + ohColumn.Item2);
                                    listOfRetailPrices.Add(columns[0] + ohColumn.Item2 + "-----" + retailPriceString);

                                    // update our budget total 
                                    runningBudgetTotal += (retailPrice * columnofOHunits); // number of OH units * retail price is the contribution to the budget


                                    // here we will drop the unnecessary columns 
                                    List<string> newColumnList = new List<string>(); // mutable string list
                                    foreach (int index in columnIndex) // same as header columns 
                                    {
                                        if (index == 100) // replace total OH value (column CW) with store's OH value
                                        {
                                            newColumnList.Add(columns[ohColumn.Item3]);
                                        }
                                        else if (index == 119) // replace total (column DP) with RetailPrice * store's OH value
                                        {
                                            newColumnList.Add((retailPrice * columnofOHunits).ToString());
                                        }
                                        else
                                        {
                                            newColumnList.Add(columns[index]); // add columns in specified index range
                                        }
                                    }

                                    newColumnList.Insert(1, ohColumn.Item2); // add column of store names

                                    string[] newColumnArray = newColumnList.ToArray(); // convert back to an array


                                    writer.WriteLine(string.Join(delimiter, newColumnArray)); // write selected line to output file
                                }

                            }
                        }


                    }


                }

                File.Delete(tempPath); // delete the sorted intermediate spreadsheet



                // now we check the inventory file to find entries with the lookup codes we found
                using (var reader = new StreamReader(inventoryPath))
                using (var writer = new StreamWriter(inventoryOutputPath))
                {
                    string line = null;
                    string[] headers = null;
                    if (firstLineContainsHeaders)
                    {
                        line = reader.ReadLine();
                        lineNumber++;

                        if (string.IsNullOrEmpty(line)) return; // file is empty;

                        headers = splitExpression.Split(line).Where(s => s != delimiter).ToArray();
                        List<string> newHeaderList = new List<string>();

                        foreach (int index in columnIndexInventory)
                        {
                            newHeaderList.Add(headers[index]); // add column header in specified index range
                        }

                        newHeaderList.Add("RetailPrice"); // add RetailPrice header

                        string[] newHeaderArray = newHeaderList.ToArray();

                        writer.WriteLine(string.Join(delimiter, newHeaderArray)); // write the original header to the temp file.
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;

                        var columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();

                        // if there are no headers, do a simple sanity check to make sure you always have the same number of columns in a line
                        if (headers == null)
                        {
                            headers = new string[columns.Length];
                        }

                        if (columns.Length != headers.Length)
                        {
                            throw new InvalidOperationException(string.Format("Line {0} is missing one or more columns.", lineNumber));
                        }

                        // next, let's find all the lines in the inventory csv that have the same lookup values as the outputPath file
                        if (lookupCodesOutput.Any(columns[0].Contains)) // if the entry columns[0], the lookup code in the inventory file, contains any elemnt from the lookup codes we saved earlier
                        {
                            // mylist.Where(x => x.Contains(myString)).FirstOrDefault();
                            string lookupAndRetailValueString = listOfRetailPrices.Where(x => x.Contains(columns[0])).FirstOrDefault();
                            string[] splitValues = lookupAndRetailValueString.Split(new[] { "-----" }, StringSplitOptions.None); // include empty array elements in the array returned
                            string retailValueString = splitValues[1];
                            List<string> newColumnList = new List<string>(); // mutable string list

                            foreach (int index in columnIndexInventory) // same as header columns 
                            {
                                newColumnList.Add(columns[index]); // add columns in specified index range
                            }

                            newColumnList.Add(retailValueString); // add RetailPrice to last column 

                            string[] newColumnArray = newColumnList.ToArray(); // convert back to an array


                            writer.WriteLine(string.Join(delimiter, newColumnArray)); // write selected line to output file
                        }



                    }


                }


                //Console.WriteLine("Value of transfer goods: " + runningBudgetTotal);
                
                // program over
                progressBar.Value = progressBar.Maximum;
                MessageBox.Show("File: " + outputPath + " and " + inventoryOutputPath + " has been created.", "Output complete");
            }
            catch (InventoryManagementException ae)
            {
                MessageBox.Show(ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        


    }
}
