namespace RandomUniqueCode.Application.Features.CQRS.ValidateCode
{
    public class ValidateCodeCommand
    {
        public ValidateCodeCommand(string code, string characters, HashSet<string> generatedCodes)
        {
            Code = code;
            Characters = characters;
            GeneratedCodes = generatedCodes;
        }

        public string Code { get; set; }
        public string Characters { get; set; }

        public HashSet<string> GeneratedCodes { get; set; }
    }

    public class ValidateCodeCommandHandler
    {

        public bool Handle(ValidateCodeCommand command)
        {
            return command.Code.All(x => !command.GeneratedCodes.Contains(command.Code) && command.Characters.Contains(x)) && command.Code.Length == 8;
        }
    }
}
