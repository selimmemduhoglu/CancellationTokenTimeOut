
using CancellationTokenTimeOut;

string connStr = "Server=mylocalhost;Database=test_db;User Id=sa;Password=sa;Connection Timeout=8";
var manager = new SqlServerManager();

var now = DateTime.Now;

var tokenSource = new CancellationTokenSource();
//var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
//tokenSource.CancelAfter(TimeSpan.FromSeconds(3));
var token = tokenSource.Token;

//_ = Task.Run(async () =>
//{
//    await Task.Delay(3_000);
//    tokenSource.Cancel();
//});

try
{
    await manager.Connect(connStr, token);
}
catch (TaskCanceledException tcex)
{
    Console.WriteLine("Task CANCELLED");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Total MS" + DateTime.Now.Subtract(now).TotalMilliseconds);
}