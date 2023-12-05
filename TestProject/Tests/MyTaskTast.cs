using ProjectB_TaskManager.Classes.General;
using ProjectB_TaskManager.Enums;

namespace TestProject.GeneralTests
{
    [TestClass]
    public class MyTaskTast
    {
        private const string category_basic = "Basic";

        [TestMethod]
        [TestCategory(category_basic)]
        public void Id_ValidInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act 
            task.Id = 1;

            // Assert
            Assert.AreEqual(1, task.Id);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Id_BelowZeroInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(()  => task.Id = 1);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Id_OverflowInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act & Assert
            Assert.ThrowsException<OverflowException>(() => task.Id = 100);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Description_ValidInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act
            task.Description = "Some description";

            // Assert
            Assert.AreEqual("Some description", task.Description);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Description_NullInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act & Arrange
            Assert.ThrowsException<ArgumentException>(() => task.Description = null);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Description_EmptyStringInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act
            task.Description = string.Empty;

            // Assert
            Assert.AreEqual(string.Empty, task.Description);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Description_OverflowInput()
        {
            // Arrange
            MyTask task = new MyTask();

            string str = new string('|', 100);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => task.Description = str);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Status_ValidInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act
            task.Status = MyTaskStatus.InProgress;

            // Assert
            Assert.AreEqual(MyTaskStatus.InProgress, task.Status);
        }
        
        [TestMethod]
        [TestCategory(category_basic)]
        public void Status_InvalidInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => task.Status = (MyTaskStatus)5 );   
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Deadline_ValidInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act
            DateTime deadline = DateTime.UtcNow.AddDays(1);
            task.Deadline = deadline;

            // Assert
            Assert.AreEqual(deadline, task.Deadline);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Deadline_InvalidInput()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => task.Deadline = new DateTime(2000, 12, 12));
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void IsOverdue_ValidReturnTrue()
        {
            // Arrange
            MyTask task = new MyTask() { Deadline = DateTime.UtcNow.AddDays(1) };

            // Act
            bool isOverdue = task.IsOverdue();

            // Assert
            Assert.IsTrue(isOverdue);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void IsOverdue_ValidReturnFalse()
        {
            // Arrange
            MyTask task = new MyTask() { Deadline = DateTime.UtcNow };

            // Act
            bool isOverdue = task.IsOverdue();

            // Assert
            Assert.IsFalse(isOverdue);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void MarkAsCompleted_Valid()
        {
            // Arrange
            MyTask task = new MyTask();

            // Act
            task.MarkAsCompleted();

            // Assert
            Assert.AreEqual(MyTaskStatus.Completed, task.Status);
        }
    }
}
