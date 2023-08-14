using RandomUniqueCode.Application.Features.CQRS.GenerateUniqueCode;

class Program
{

    static void Main(string[] args)
    {
        var handler = new GenerateUniqueCodeCommandHandler();
        var codes = handler.Handle(new GenerateUniqueCodeCommand
        {
            Count = 1000,
            Characters = "ACDEFGHKLMNPRTXYZ234579"
        });


        foreach (var code in codes)
        {
            Console.WriteLine(code);
        }
    }



}
