using System.Runtime.CompilerServices;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("List created asynchronusly");
        await ShowList();
    }

    #region Processing elements right away when we get them asynchronusly
    static async IAsyncEnumerable<int> CreateListAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(500);
            yield return i;
        }
    }

    static async Task ShowList()
    {
        await foreach (var item in CreateListAsync())
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
        }
    }
    #endregion Processing elements right away when we get them asynchronusly

    //#region Waiting till we get the LAST element, then processing some logic over them all in one go | NOT THE BEST APPROACH!!!
    //static async Task<IEnumerable<int>> CreateListAsync()
    //{
    //    List<int> list = new List<int>();

    //    for (int i = 0; i < 10; i++)
    //    {
    //        await Task.Delay(500);
    //        list.Add(i);
    //    }

    //    return list;
    //}

    //static async Task ShowList()
    //{
    //    foreach (var item in await CreateListAsync())
    //    {
    //        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
    //    }
    //}
    //#endregion Waiting till we get the LAST element, then processing some logic over them all in one go | NOT THE BEST APPROACH!!!
}