using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Program
{
  class Program
  {
     static void Main(string[] args)
     {
      Console.WriteLine("Loading Data...");
   		TestXML XML_1 = new TestXML("Data_Book.xml");
      XML_1.Insert_Element();
      XML_1.Update_Element(99);
      XML_1.Delete_Element(99);
      //Console.WriteLine("Loading Complete");
      //Console.WriteLine("Saving New Data XML File");
      //XML_1.Create_XML();
      //Console.WriteLine("Saved");
        /*
        Console.WriteLine("What is do you want to search?");
        Console.WriteLine("Please Insert Attribute for search:\n[Title,Price,Author,Year,Category,ISBN-10,ISBN-13]");
       	string Temp_Attr = Console.ReadLine();
        Temp_Attr = Temp_Attr.ToLower();
        while (!(Temp_Attr == "title" || Temp_Attr == "price" || Temp_Attr == "category" || Temp_Attr == "author" || Temp_Attr == "year" ||Temp_Attr == "isbn-10" || Temp_Attr == "isbn-13"))
        {
          Console.WriteLine("INPUT :"+Temp_Attr);
          Console.WriteLine("Please Insert Attribute for search:\n[Title,Price Author,Year,Category,ISBN-10,ISBN-13]");
          Temp_Attr = Console.ReadLine();
          Temp_Attr = Temp_Attr.ToLower();
        }
        Console.WriteLine("Please Insert Key for search:");
        string temp = Console.ReadLine();        
        //XML_1.DisplayAll();
        XML_1.Search(temp,Temp_Attr);
        */
        //Console.ReadKey();
     }
  }
  class TestXML
  {
  	public List<string> Title 	= new List<string>();
  	public List<float> 	Price 	= new List<float>();
  	public List<string> Author 	= new List<string>();
  	public List<int> 	Year 	    = new List<int>();
  	public List<string> Category= new List<string>();
  	public List<string> ISBN_10 = new List<string>();
  	public List<string> ISBN_13 = new List<string>();
  	public XDocument xdoc = new XDocument();
    private string Location ;
    public int Count_length ;

  	//Load Data
  	public TestXML(string Path)
  	{
        xdoc = XDocument.Load(Path);
        stored();
        this.Location = Path;

    }
    private void Find_length()
    {

    }
    private void stored()
    {
      int i = 0;
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
    //Add Item No Parameter for testing
    public void Insert_Element()
    {
      XElement Insert_Data = new XElement("book");
      Insert_Data.Add(new XAttribute("ID","99"));
      Insert_Data.Add(new XElement("Title","Testing"));
      Insert_Data.Add(new XElement("Price","99"));
      Insert_Data.Add(new XElement("Author","Tester"));
      Insert_Data.Add(new XElement("Year","1999"));
      Insert_Data.Add(new XElement("Category","Computer"));
      Insert_Data.Add(new XElement("ISBN-10","9999999999"));
      Insert_Data.Add(new XElement("ISBN-13","9999999999999"));
      //Console.WriteLine(Insert_Data);
      xdoc.Element("bookstore").Add(Insert_Data);
      Console.WriteLine(xdoc.Element("bookstore"));
    }
    //Add Item
    public void Insert_Element(string title , string price ,string author,string year ,string category ,string ISBN_10,string ISBN_13)
    {
      XElement Insert_Data = new XElement("book");
      Insert_Data.Add(new XAttribute("ID",this.Count()+1));
      Insert_Data.Add(new XElement("Title",title));
      Insert_Data.Add(new XElement("Price",price));
      Insert_Data.Add(new XElement("Author",author));
      Insert_Data.Add(new XElement("Year",year));
      Insert_Data.Add(new XElement("Category",category));
      Insert_Data.Add(new XElement("ISBN-10",ISBN_10));
      Insert_Data.Add(new XElement("ISBN-13",ISBN_13));
      //Console.WriteLine(Insert_Data);
      xdoc.Element("bookstore").Add(Insert_Data);
      Console.WriteLine(xdoc.Element("bookstore"));
    }
    //Update Items
    public void Update_Element(int check)
    {
      //xdoc.Elements("bookstore").Elements("book").Where(x => (string)x.Attribute("ID") == check.ToString()).SetElementValue("Title","Update_Name");
      Console.WriteLine(xdoc.Element("bookstore"));
    }
    //Remove Items
    public void Delete_Element(int check)
    {
      xdoc.Elements("bookstore").Elements("book").Where(x => (string)x.Attribute("ID") == check.ToString()).Remove();
      Console.WriteLine(xdoc.Element("bookstore"));
    }
    //Display All
    public void DisplayAll()
    {
    	var result = xdoc.Element("bookstore").Descendants();
    	foreach (XElement item in result)
    	{
    		Console.WriteLine(item.Name +" : " + item.Value);
    	}
    }
    public int Count()
    {
      return Title.Count;
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
		//Check Title
		if (Attribute == "title")
		{
			for (int i = 0; i< Title.Count;i++)
			{
				if (Find == Title[i])
				{
					Display_one(i);
				}
			}
		}
		//Check Category
    if (Attribute == "category")
		{
			for (int i = 0; i< Category.Count;i++)
			{
				if (Find == Category[i])
				{
					Display_one(i);
				}
			}
		}
    //Check Price
    if (Attribute == "price")
    {
      for (int i = 0; i< Price.Count;i++)
      {
        if (float.Parse(Find) == Price[i])
        {
          Display_one(i);
        }
      }
    }
    //Check Year
		if (Attribute == "year")
    {
      for (int i = 0; i< Year.Count;i++)
      {
        if (int.Parse(Find) == Year[i])
        {
          Display_one(i);
        }
      }
    }
    //Check Author
    if (Attribute == "author")
    {
      for (int i = 0; i< Author.Count;i++)
      {
        if (Find == Author[i])
        {
          Display_one(i);
        }
      }
    }
	}
	//Search with Condition
	public void Search_Condition(string Type,string condition ,float Value)
	{  
    if (Type == "price")
    {
      
    }
	}
  //Create XML
  public void Create_XML(){
    string Data_XML = "";
    //Add Header
    Data_XML = Data_XML + "<?xml version =\"1.0\" encoding=\"utf-8\"?>";
    //Add Open bookstore
    Data_XML = Data_XML + "<bookstore>";
    //Add Book
    for ( int i = 0 ;i<Title.Count;i++)
    {
      Data_XML = Data_XML +"<book ID=\"" +(i+1).ToString() +"\">";
      Data_XML = Data_XML +"<ISBN-10>" +ISBN_10[i] +"</ISBN-10>";
      Data_XML = Data_XML +"<ISBN-13>" +ISBN_13[i] +"</ISBN-13>";
      Data_XML = Data_XML +"<Title>" +Title[i] +"</Title>";
      Data_XML = Data_XML +"<Author>" +Author[i] +"</Author>";
      Data_XML = Data_XML +"<Price>" +Price[i] +"</Price>";
      Data_XML = Data_XML +"<Category>" +Category[i] +"</Category>";
      Data_XML = Data_XML +"</book>";
     }
    //Add Close bookstore
    Data_XML = Data_XML + "</bookstore>";
    XmlDocument New_XML = new XmlDocument();
    New_XML.LoadXml(Data_XML);
    Console.WriteLine(New_XML);
    New_XML.Save("NEW_Data.xml");
    
  }
 private bool Operator(string logic, int x, int y)
    {
        switch (logic)
        {
            case ">": return x > y;
            case "<": return x < y;
            case "==": return x == y;
            default: throw new Exception("invalid logic");
        }
    }
  }
}
