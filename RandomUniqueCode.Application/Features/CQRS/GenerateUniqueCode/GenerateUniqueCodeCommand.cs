using RandomUniqueCode.Application.Features.CQRS.ValidateCode;

namespace RandomUniqueCode.Application.Features.CQRS.GenerateUniqueCode
{
    public class GenerateUniqueCodeCommand
    {
        public int Count { get; set; }
        public string Characters { get; set; } = "ACDEFGHKLMNPRTXYZ234579";
    }

    public class GenerateUniqueCodeCommandHandler
    {
        HashSet<string> GenereatedCodeList = new HashSet<string>();
        public HashSet<string> Handle(GenerateUniqueCodeCommand command)
        {
            var generatedUniqueCodeList = new HashSet<string>();


            var random = new Random();


            while (generatedUniqueCodeList.Count < command.Count)
            {
                var chars = new char[8];
                for (int i = 0; i < 8; i++)
                {
                    var randomIndex = random.Next(0, command.Characters.Length);
                    chars[i] = command.Characters[randomIndex];
                }

                var generatedCode = new string(chars);


                ValidateCodeCommandHandler handler = new ValidateCodeCommandHandler();

                if (handler.Handle(new ValidateCodeCommand(code: generatedCode, characters: command.Characters, generatedCodes: GenereatedCodeList)))
                {
                    GenereatedCodeList.Add(generatedCode);
                    generatedUniqueCodeList.Add(generatedCode);
                }
            }

            return generatedUniqueCodeList;


        }
    }
}
