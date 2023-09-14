using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using SampleHierarchies.Services;
using System;
using System.IO;

[TestClass]
public class ScreenDefinitionServiceTests
{
    private const string ValidJsonFileName = "valid.json";
    private const string InvalidJsonFileName = "invalid.json";
    private const string NonExistentJsonFileName = "nonexistent.json";

    [TestMethod]
    public void Load_ValidJsonFile_ReturnsScreenDefinition()
    {
        // Arrange
        File.WriteAllText(ValidJsonFileName, "{\"LineEntries\":[{\"Text\":\"Test\",\"ForegroundColor\":\"White\",\"BackgroundColor\":\"Black\"}]}");

        // Act
        var screenDefinition = ScreenDefinitionService.Load(ValidJsonFileName);

        // Assert
        Assert.IsNotNull(screenDefinition);
        Assert.IsNotNull(screenDefinition.LineEntries);
        Assert.AreEqual("Test", screenDefinition.LineEntries[0].Text);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Bad read from file")]
    public void Load_InvalidJsonFile_ThrowsException()
    {
        // Arrange
        File.WriteAllText(InvalidJsonFileName, "Invalid JSON");

        // Act & Assert
        ScreenDefinitionService.Load(InvalidJsonFileName);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "File is not found")]
    public void Load_NonExistentJsonFile_ThrowsException()
    {
        // Act & Assert
        ScreenDefinitionService.Load(NonExistentJsonFileName);
    }

    [TestMethod]
    public void ShowLine_ValidJsonFileAndValidLineEntry_PrintsLine()
    {
        // Arrange
        File.WriteAllText(ValidJsonFileName, "{\"LineEntries\":[{\"Text\":\"Test\",\"ForegroundColor\":\"White\",\"BackgroundColor\":\"Black\"}]}");

        // Act
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            ScreenDefinitionService.ShowLine(ValidJsonFileName, 0);
            var output = sw.ToString().Trim();

            // Assert
            Assert.AreEqual("Test", output);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "File is not found")]
    public void ShowLine_NonExistentJsonFile_ThrowsException()
    {
        // Act & Assert
        ScreenDefinitionService.ShowLine(NonExistentJsonFileName, 0);
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Clean up created files
        File.Delete(ValidJsonFileName);
        File.Delete(InvalidJsonFileName);
    }
}
