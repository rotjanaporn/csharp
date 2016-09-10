using System;
using System.Collections.Generic;
using System.Text;
using SequelMaxNet;
using System.Linq;
namespace Example
{
	class book
	{
		public int ID;
		public string ISBN_10;
		public string ISBN_13;
		public string Title;
		public string Author;
		public double Price;
		public string Year;
		public string Category;

	}
	class Program
	{
		static string GetFolderPath()
		{
			return @"..\..\..\";
		}
		static void Main(string[] args)
		{
			List<book> list = new List<book>();
			if (ReadDoc(GetFolderPath() + "Data_Book.xml", list))
				DisplayDoc(list);
			else
				Console.WriteLine("Cannot read file!");
		}
		static bool ReadDoc(string file, List<book> list)
		{
			SequelMaxNet.Document doc = new SequelMaxNet.Document();
			doc.RegisterStartElementDelegate("bookstore|book", (elem) =>
			{
				book emp = new book();
				emp.ID = elem.Attr("ID").GetInt32(0);
				list.Add(emp);
			});
			doc.RegisterEndElementDelegate("bookstore|book|ISBN_10", (text) =>
			{
				list[list.Count - 1].ISBN_10 = text;
			});
			doc.RegisterEndElementDelegate("bookstore|book|ISBN_13", (text) =>
			{
				list[list.Count - 1].ISBN_13 = text;
			});
			doc.RegisterEndElementDelegate("bookstore|book|Title", (text) =>
			{
				list[list.Count - 1].Title = text;
			});
			doc.RegisterEndElementDelegate("bookstore|book|Author", (text) =>
			{
				list[list.Count - 1].Author = text;
			});
			doc.RegisterEndElementDelegate("bookstore|book|Price", (text) =>
			{
				Double.TryParse(text, out list[list.Count - 1].Price);
			});
			doc.RegisterEndElementDelegate("bookstore|book|Year", (text) =>
			{
				list[list.Count - 1].Year = text;
			});
			doc.RegisterEndElementDelegate("bookstore|book|Category", (text) =>
			{
				list[list.Count - 1].Category = text;
			});


			return doc.Open(file);
		}
		static void DisplayDoc(List<book> list)
		{
			for (int i = 0; i < list.Count; ++i)
			{
				Console.WriteLine("Book ID: {0}", list[i].ID);
				Console.WriteLine("ISBN-10: {0}", list[i].ISBN_10);
				Console.WriteLine("ISBN-13: {0}", list[i].ISBN_13);
				Console.WriteLine("Title: {0}", list[i].Title);
				Console.WriteLine("Author: {0}", list[i].Author);
				Console.WriteLine("Price: {0}", list[i].Price);
				Console.WriteLine("Year: {0}", list[i].Year);
				Console.WriteLine("Category: {0}", list[i].Category);
				Console.WriteLine();
			}
		}
	}
}



