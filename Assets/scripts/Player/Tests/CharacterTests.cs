using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterTests : InputTestFixture
{
    GameObject character = Resources.Load<GameObject>("pj.temp");
    Keyboard keyboard;

    // A Test behaves as an ordinary method
    [Test]
    public void TestPlayerInstantiation()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);

        var playerHealth = characterInstance.GetComponent<PlayerHealth>();
        Assert.That(playerHealth, Is.Not.Null, "PlayerHealth component not found on character prefab.");

        GameObject mockDeathPanel = new GameObject("MockDeathPanel");
        playerHealth.deathPanel = mockDeathPanel;

        Assert.That(characterInstance, Is.Not.Null);
    }

    //public void CharacterTestsSimplePasses()
    //{
    //    // Use the Assert class to test conditions
    //}

    //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    //// `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator CharacterTestsWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}
}
