﻿internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Todo_Console started");
        //
        Display_Todos_CRUD_UI();
        //
        Console.WriteLine("Todo_Console ended");
    }

    private static void Display_Todos_CRUD_UI()
    {
        TodosDB tdbc = new TodosDB("Data Source=.\\sqlexpress;Initial Catalog=Todos;Integrated Security=True");
        string selection = null, title, newTitle, isComplete;
        const string MENU = @"Enter your selection:
                s = show all items
                c = create item
                cc = create items (in CSV format)
                u = update item
                d = delete item
                q = quit app";
        while (selection != "q")
        {
            Console.Clear();
            Console.WriteLine(MENU);
            selection = Console.ReadLine().Trim().ToLower();
            if (selection == "s")
            {
                Console.WriteLine("Showing all items");
                foreach (var item in tdbc.GetAllItems())
                    Console.WriteLine(item);
            }
            else if (selection == "c")
            {
                Console.WriteLine("Enter title and press enter");
                title = Console.ReadLine().Trim();
                Console.WriteLine("Enter isComplete (false | true) and press enter");
                isComplete = Console.ReadLine().Trim().ToLower();
                //
                tdbc.InsertItem(new Item() { Title = title, IsCompleted = bool.Parse(isComplete) });

            }
            else if (selection == "cc")
            {
                Console.WriteLine("Enter titles in CSV format and press enter");
                string[] titles = Console.ReadLine().Trim().Split(',');
                List<Item> items = new List<Item>();
                foreach (var t in titles)
                    items.Add(new Item() { Title = t });
                //
                tdbc.InsertItems(items);

            }
            else if (selection == "u")
            {
                Console.WriteLine("Enter old title and press enter");
                title = Console.ReadLine().Trim();
                Console.WriteLine("Enter new title and press enter");
                newTitle = Console.ReadLine().Trim();
                Console.WriteLine("Enter new isComplete (false | true) and press enter");
                isComplete = Console.ReadLine().Trim().ToLower();
                //
                Item item = tdbc.GetItem(title);
                if (item != null)
                {
                    item.Title = newTitle;
                    item.IsCompleted = bool.Parse(isComplete);
                    tdbc.UpdateItem(item);
                }
                else
                    Console.WriteLine($"Task with title '{title}' was not found");
            }
            else if (selection == "d")
            {
                Console.WriteLine("Enter title and press enter");
                title = Console.ReadLine().Trim();
                //
                Item item = tdbc.GetItem(title);
                if (item != null)
                {
                    tdbc.DeleteItem(item);
                }
                else
                    Console.WriteLine($"Task with title '{title}' was not found");

            }
            else if (selection != "q")
            {
                Console.WriteLine("Invalid selection");
            }
            Console.WriteLine("Press any key to show the selection menu");
            Console.ReadLine();
        }
    }
}