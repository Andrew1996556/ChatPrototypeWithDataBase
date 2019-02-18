using Chat.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chat.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void PostMessage_RegistrationNewAnswer_AnswersHasAnswer()
        {
            var CController = new ChatController();

            string userName = "Andrew";
            string message = "Hi";

            CController.PostMessage(message, userName);

            Assert.IsNotNull(ChatController.Answers.Count);
        }

        [TestMethod]
        public void GetSerializableAnswer_GetRegistrationAnsvwer_AnswerGetNotNull()
        {
            var CController = new ChatController();

            var result = CController.GetSerializableAnswers();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HalloWorld_TestedMethod_ResultHelloWorld()
        {
            var CController = new ChatController();

            var result = CController.HelloWorld();

            Assert.IsNotNull(result);
        }

       [TestMethod]
        public void AddHistory_AddNewAnswerInDateBase_ReturnContainsTrue()
        {
            HistoryContext db = new HistoryContext();
            string userNameTest = "Andrew1";
            string MessageTest = "Hi3";
            var history = new HistoryInfo { userName = userNameTest, Message = MessageTest };

            db.Users.ToList();
            DBRequestsController.AddHistory(userNameTest, MessageTest);
           
            Assert.IsTrue();
        }
    }
}
