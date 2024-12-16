using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterTests : InputTestFixture
{
    GameObject character = Resources.Load<GameObject>("Player");
    Keyboard keyboard;

    // A Test behaves as an ordinary method
    [Test]
    public void TestPlayerInstantiation()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);
        Assert.That(character, Is.Not.Null, "Player prefab was not found in Resources.");

        PlayerHealth playerHealth = characterInstance.GetComponent<PlayerHealth>();
        Assert.That(playerHealth, Is.Not.Null, "PlayerHealth component not found on character prefab.");

        // Si deathPanel es nulo, asignamos un objeto temporal para evitar el error.
        if (playerHealth.deathPanel == null)
        {
            GameObject mockDeathPanel = new GameObject("MockDeathPanel");
            playerHealth.deathPanel = mockDeathPanel;
        }

        var rigidbody = characterInstance.GetComponent<Rigidbody2D>();
        Assert.That(rigidbody, Is.Not.Null, "Player does not have a Rigidbody2D component.");

        Assert.That(characterInstance.CompareTag("Player"), Is.True, "Player tag is not correctly assigned.");
    }

    [UnityTest]
    public IEnumerator TestPlayerInstantiationInPlayMode()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);

        // Esperar un frame para simular el ciclo de juego
        yield return null;

        Assert.That(characterInstance, Is.Not.Null, "Player character was not instantiated.");
    }
    public IEnumerator TestPlayerMoves()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);
        Press(keyboard.spaceKey);
        yield return new WaitForSeconds(1f);
        Release(keyboard.spaceKey);
        yield return new WaitForSeconds(1f);
        Assert.That(characterInstance.transform.GetChild(0).transform.position.z, Is.GreaterThan(1.5f));
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
