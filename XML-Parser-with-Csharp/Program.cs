using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Program
{
  class Program
  {
     static void Main(string[] args)
     {
   	TestXML XML_1 = new TestXML("Data_Book.xml");
        Console.WriteLine("\nWhat is category do you want to search?");
       	string temp = Console.ReadLine();
        //XML_1.DisplayAll();
        XML_1.Search(temp,"Category");

        //Console.ReadKey();
     }
  }
  class TestXML
  {
  	public List<string> Title 	= new List<string>();
  	public List<float> 	Price 	= new List<float>();
  	public List<string> Author 	= new List<string>();
  	public List<int> 	Year 	= new List<int>();
  	public List<string> Category= new List<string>();
  	public List<string> ISBN_10 = new List<string>();
  	public List<string> ISBN_13 = new List<string>();
  	public XDocument xdoc = new XDocument();

  	//Load Data
  	public TestXML(string Path)
  	{
        xdoc = XDocument.Load(Path);
        stored();
    }
    private void stored()
    {
    	var result = xdoc.Element("bookstore").Descendants();
        foreach (XElement item in result)
        {
        	if (item.Name == "Title")
        	{
           		//Console.WriteLine(item.Name+" " + item.Value);
           		Title.Add(item.Value);
        	}
        	if (item.Name == "Price")
        	{
           		//Console.WriteLine(item.Name+" " + item.Value);
           		Price.Add(float.Parse(item.Value));
        	}
        	if (item.Name == "Author")
        	{
           		//Console.WriteLine(item.Name+" " + item.Value);
           		Author.Add(item.Value);
        	}
        	if (item.Name == "Year")
        	{
           		//Console.WriteLine(item.Name+" " + item.Value);
           		Year.Add(int.Parse(item.Value));
        	}
        	if (item.Name == "Category")
        	{
           		//Console.WriteLine(item.Name+" " + item.Value);
           		Category.Add(item.Value);
        	}
        	if (item.Name == "ISBN-10")
        	{
           		//Console.WriteLine(item.Name+" " + item.Value);
           		ISBN_10.Add(item.Value);
        	}
        	if (item.Name == "ISBN-13")
        	{
           		//Console.WriteLine(item.Name+" " + item.Value);
           		ISBN_13.Add(item.Value);
        	}
        }
    }
    //Display All
    public void DisplayAll()
    {
    	var result = xdoc.Element("bookstore").Descendants();
    	foreach (XElement item in result)
    	{
    		Console.WriteLine(item.Name +" " + item.Value);
    	}
    }
    //Display In Table
    public void DisplayTable()
    {

    }
    //Display One Attribute
    public void Display(string Name)
    {

    }
    //Display Only One book
    public void Display_one(int index)
    {
    	Console.WriteLine("___________________________________________________________________________________");
    	Console.WriteLine("Title		:	"+Title[index]);
    	Console.WriteLine("Author		:	"+Author[index]);
    	Console.WriteLine("Year		:	"+Year[index]);
    	Console.WriteLine("Price		:	$"+Price[index]);
    	Console.WriteLine("Category	:	"+Category[index]);
    	Console.WriteLine("ISBN_10		:	"+ISBN_10[index]);
    	Console.WriteLine("ISBN_13		:	"+ISBN_13[index]);
    	Console.WriteLine("___________________________________________________________________________________");
	}
    //Search
	public void Search(string Find,string Attribute)
	{
		//int index;
		if (Attribute == "Title")
		{
			for (int i = 0; i< Title.Count;i++)
			{
				if (Find == Title[i])
				{
					//Console.WriteLine("INDEX " + i);
					Display_one(i);
				}
				//Console.WriteLine(Category.IndexOf(Find));
			}
			//index = Title.IndexOf(Find);
			//Console.WriteLine(Title.IndexOf(Find));
		}
		if (Attribute == "Category")
		{
			//index = Title.IndexOf(Find);
			for (int i = 0; i< Category.Count;i++)
			{
				if (Find == Category[i])
				{
					//Console.WriteLine("INDEX " + i);
					Display_one(i);
				}
				//Console.WriteLine(Category.IndexOf(Find));
			}
		}
		//Console.WriteLine( index);
	}
	//Search with Condition
	public void Search_Condition()
	{

	}
  }
}

