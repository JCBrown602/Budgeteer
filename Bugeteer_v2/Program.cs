﻿using System;
using System.Collections.Generic;
using System.IO; // for StreamReader/Writer
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bugeteer_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<string> csvList = new List<string>();
            Bill newBill = new Bill();

            try
            {
                foreach (string line in File.ReadLines("numbers.csv"))
                {
                    // Removes the double quotes from the transaction line
                    // REF: https://www.dotnetperls.com/remove-char
                    int index = 0;
                    char[] result = new char[line.Length];
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] != '"')
                        {
                            result[index++] = line[i];
                        }
                    }

                    string fixedLine = new string(result, 0, index);

                    list.Add(fixedLine);
                }

                int count = 0;
                using (TextWriter tw = new StreamWriter("list3.txt"))
                {
                    foreach (var item in list)
                    {
                        string[] splitStr = list[count].Split(',');
                        newBill.Date = splitStr[0];
                        newBill.Amt = splitStr[1];
                        newBill.Star = splitStr[2];
                        newBill.Blank = splitStr[3];
                        newBill.Desc = splitStr[4];
                        Console.WriteLine(newBill.DisplayBill());
                        tw.WriteLine(newBill.DisplayBill());
                        count++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("> File not found.");
            }

        }
    }

    class Bill
    {
        string _date   = null;
        string _amt    = null;
        string _star   = null;
        string _blank  = null;
        string _desc   = null;

        public Bill(){}

        public Bill(string date, string amt, string star, string blank, string desc)
        {
            this._date  = date;
            this._amt   = amt;
            this._star  = star;
            this._blank = blank;
            this._desc  = desc;
        }

        #region Getters & Setters
        public string Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }
        public string Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }
        public string Star
        {
            get
            {
                return this._star;
            }
            set
            {
                this._star = value;
            }
        }
        public string Blank
        {
            get
            {
                return this._blank;
            }
            set
            {
                this._blank = value;
            }
        }
        public string Desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }
        #endregion

        public string DisplayBill()
        {
            string billStr = null;

            billStr = Date + "\t" + Amt;

            return billStr;
        }

        // DEBUG: This method is not complete!
        public string DisplayBill(Bill[] multipleBills)
        {
            string billStr = null;

            billStr = Date + "\t" + Amt + "\t" + Desc;

            return billStr;
        }
    }
}
