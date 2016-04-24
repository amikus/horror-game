using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class KeySpawnTests {

    [Test]
    public void EditorTest()
    {
        //Arrange
        var point1 = new GameObject();
        point1.tag = "KeySpawnPoints";
        var keys = new PickupController();

        //Act
        //Try to create spawn points
        



        //Assert
        //The object has a new name
        Assert.AreEqual(point1.tag, "KeySpawnPoints");
    }
}
