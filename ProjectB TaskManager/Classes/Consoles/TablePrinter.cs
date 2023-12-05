using System;
using System.Collections.Generic;

namespace ProjectB_TaskManager.Classes.Consoles
{
    public class TablePrinter
    {
        private readonly List<ITablePrintable> printableObjects;

        public TablePrinter(List<ITablePrintable> printableObjects)
        {
            this.printableObjects = printableObjects;
        }

        public void PrintTable()
        {
            Console.WriteLine(printableObjects[0].GetTableFooter());
            Console.WriteLine(printableObjects[0].GetTableHeader());
            Console.WriteLine(printableObjects[0].GetTableFooter());

            foreach (ITablePrintable item in printableObjects)
            {
                Console.WriteLine(item.GetTableRow());
                Console.WriteLine(item.GetTableFooter());
            }
        }
    }
}