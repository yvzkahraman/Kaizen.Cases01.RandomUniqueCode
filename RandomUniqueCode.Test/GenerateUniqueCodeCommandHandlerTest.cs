using RandomUniqueCode.Application.Features.CQRS.GenerateUniqueCode;

namespace RandomUniqueCode.Test
{
    public class GenerateUniqueCodeCommandHandlerTest
    {
        private readonly GenerateUniqueCodeCommandHandler handler;
        public GenerateUniqueCodeCommandHandlerTest()
        {
            this.handler = new GenerateUniqueCodeCommandHandler();
        }


        [Theory]
        [InlineData(4)]
        public void GenerateUniqueCodeCommandHandler_ShouldReturnSuccess_WhenValidData(int count)
        {
            var command = new GenerateUniqueCodeCommand
            {
                Characters = "ACDEFGHKLMNPRTXYZ234579",
                Count = 4
            };
            var result = handler.Handle(command);

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }

}
