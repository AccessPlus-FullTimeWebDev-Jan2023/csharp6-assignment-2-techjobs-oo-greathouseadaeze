
namespace TechJobs.Tests
{
    [TestClass]
    public class JobTests
    {
        Job job1 = new Job();

        Job job2 = new Job();

        Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        Job job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));


        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreNotEqual(job1.Id, job2.Id);
            Assert.IsTrue(job2.Id - job1.Id == 1);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester", job3.Name);
            Assert.AreEqual("ACME", job3.EmployerName.ToString());
            Assert.AreEqual("Desert", job3.EmployerLocation.ToString());
            Assert.AreEqual("Quality control", job3.JobType.ToString());
            Assert.AreEqual("Persistence", job3.JobCoreCompetency.ToString());
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job3.Equals(job4));
        }

        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            Assert.IsTrue(job3.ToString().StartsWith(Environment.NewLine));
            Assert.IsTrue(job3.ToString().EndsWith(Environment.NewLine));
        }

        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            string expected = Environment.NewLine + $"ID: {job3.Id}" + Environment.NewLine + $"Name: {job3.Name}" + Environment.NewLine + $"Employer: {job3.EmployerName.ToString()}" + Environment.NewLine + $"Location: {job3.EmployerLocation.ToString()}" + Environment.NewLine + $"Position Type: {job3.JobType.ToString()}" + Environment.NewLine + $"Core Competency: {job3.JobCoreCompetency.ToString()}" + Environment.NewLine;
            string actual = job3.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            job3.Name = "";
            string expected = Environment.NewLine + $"ID: {job3.Id}" + Environment.NewLine + $"Name: Data not available" + Environment.NewLine + $"Employer: {job3.EmployerName.ToString()}" + Environment.NewLine + $"Location: {job3.EmployerLocation.ToString()}" + Environment.NewLine + $"Position Type: {job3.JobType.ToString()}" + Environment.NewLine + $"Core Competency: {job3.JobCoreCompetency.ToString()}" + Environment.NewLine;
            string actual = job3.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}

