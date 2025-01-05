using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRacer : MonoBehaviour
{
    // Variables
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";
    public int carWeight = 1609;
    public int yearMade = 2009;
    public float maxAcceleration = 0.98f;
    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;
    public string carMaker;

    // Nested Fuel class
    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    public Fuel carFuel = new Fuel(100);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"The car maker is {carMaker}, the model is {carModel}, and it has an {engineType}.");
        CheckWeight();

        if (yearMade <= 2009)
        {
            Debug.Log($"The car was introduced in {yearMade}.");
            int carAge = CalculateAge(yearMade);
            Debug.Log($"The car is {carAge} years old.");
        }
        else
        {
            Debug.Log("The car was introduced in the 2010's.");
            Debug.Log($"The car's maximum acceleration is {maxAcceleration}.");
        }

        Debug.Log(CheckCharacteristics());
    }

    // CheckWeight function
    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            Debug.Log($"The {carModel} weighs less than 1500 kg.");
        }
        else
        {
            Debug.Log($"The {carModel} weighs over 1500 kg.");
        }
    }

    // CalculateAge function
    int CalculateAge(int year)
    {
        return 2023 - year;
    }

    // CheckCharacteristics function
    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return "The car type is a sedan.";
        }
        else if (hasFrontEngine)
        {
            return "The car is not a sedan but has a front engine.";
        }
        else
        {
            return "The car is neither a sedan nor does it have a front engine.";
        }
    }

    // ConsumeFuel function
    void ConsumeFuel()
    {
        carFuel.fuelLevel -= 10;
    }

    // CheckFuelLevel function
    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                Debug.Log("Fuel level is nearing two-thirds.");
                break;
            case 50:
                Debug.Log("Fuel level is at half amount.");
                break;
            case 10:
                Debug.Log("Warning! Fuel level is critically low.");
                break;
            default:
                Debug.Log("Fuel level is fine, nothing to report.");
                break;
        }
    }

    // Update function
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }
}
