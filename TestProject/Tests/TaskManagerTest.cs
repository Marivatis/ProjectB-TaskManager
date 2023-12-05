using ProjectB_TaskManager.Classes.General;
using ProjectB_TaskManager.Enums;
using System.Data;

namespace TestProject.GeneralTests
{
    [TestClass]
    public class TaskManagerTest
    {
        private const string category_iCollection = "ICollection";
        private const string category_basic = "Basic";

        [TestMethod]
        [TestCategory(category_iCollection)]
        public void Count_ValidReturn() 
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act
            int result = tasks.Count;

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [TestCategory(category_iCollection)]
        public void Count_ZeroReturn()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager();

            // Act
            int result = tasks.Count;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Add_ValidInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager();

            MyTask task = new MyTask(1, "New Task", new DateTime(17, 9, 2008), MyTaskStatus.NotStarted);

            // Act
            tasks.Add(task);

            // Assert
            CollectionAssert.Contains(tasks, task);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Add_NullInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager();

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => tasks.Add(null));
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Add_DuplicateInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager();

            // Act
            tasks.Add(new MyTask(1, "New Task 1", new DateTime(17, 9, 2008), MyTaskStatus.NotStarted));

            // Act & Assert
            Assert.ThrowsException<DuplicateNameException>(
                ()  => tasks.Add(new MyTask(1, "New Task 2", new DateTime(27, 11, 2020), MyTaskStatus.InProgress)));
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Clear_Clears()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act
            tasks.Clear();

            // Assert
            Assert.AreEqual(0, tasks.Count);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Contains_ExistTaskInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act
            bool result = tasks.Contains(new MyTask(3, "New Task", new DateTime(17, 9, 2008), MyTaskStatus.NotStarted));

            // Assert
            Assert.IsTrue(result);
            CollectionAssert.Contains(tasks, new MyTask(3, "New Task", new DateTime(17, 9, 2008), MyTaskStatus.NotStarted));
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Contains_NotExistentTaskInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act
            bool result = tasks.Contains(new MyTask());

            // Assert
            Assert.IsFalse(result);
            CollectionAssert.DoesNotContain(tasks, new MyTask());
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Contains_NullInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => tasks.Contains(null));
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Remove_ExistTaskInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act
            bool result = tasks.Remove(new MyTask(3, "New Task", new DateTime(17, 9, 2008), MyTaskStatus.NotStarted));

            // Assert
            Assert.IsTrue(result);
            CollectionAssert.DoesNotContain(tasks, new MyTask(3, "New Task", new DateTime(17, 9, 2008), MyTaskStatus.NotStarted));
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Remove_NotExistenTaskInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act
            bool result = tasks.Remove(new MyTask());

            // Assert
            Assert.IsFalse(result);
            CollectionAssert.Contains(tasks, new MyTask());
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void Remove_NullInput()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => tasks.Remove(null));
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void ToList_FullManager()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager()
            {
                new MyTask(1, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(2, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(3, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted),
                new MyTask(4, "New Task", new DateTime(2008, 9, 17), MyTaskStatus.NotStarted)
            };

            // Act
            List<MyTask> list = tasks.ToList();

            // Assert
            CollectionAssert.AreEquivalent(tasks, list);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void ToList_EmptyManager()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager();

            // Act
            List<MyTask> list = tasks.ToList();

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void SortTasksByReamingDate_SortsCorrectly()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager();

            MyTask task1 = new MyTask(1, "New Task", DateTime.UtcNow.AddDays(1), MyTaskStatus.NotStarted);
            MyTask task2 = new MyTask(2, "New Task", DateTime.UtcNow.AddDays(3), MyTaskStatus.NotStarted);
            MyTask task3 = new MyTask(3, "New Task", DateTime.UtcNow.AddDays(4), MyTaskStatus.NotStarted);
            MyTask task4 = new MyTask(4, "New Task", DateTime.UtcNow.AddDays(2), MyTaskStatus.NotStarted);

            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);

            // Act
            tasks.SortTasksByReamingDate();

            // Assert
            CollectionAssert.AreEqual(new MyTaskManager { task1, task4, task2, task3 }, tasks);
        }

        [TestMethod]
        [TestCategory(category_basic)]
        public void SortTasksByReamingDate_EmptyManager()
        {
            // Arrange
            MyTaskManager tasks = new MyTaskManager();

            // Act
            tasks.SortTasksByReamingDate();

            // Assert
            CollectionAssert.AreEqual(new MyTaskManager(), tasks);
        }
    }
}