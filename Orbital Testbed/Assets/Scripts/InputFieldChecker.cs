using UnityEngine;
using TMPro;

public class InputFieldChecker : MonoBehaviour
{
    public OrbitCalculator orbitCalculator;

    public void ChangeValue(TMP_InputField inputField) {
        string value = inputField.gameObject.name;

        if (inputField.text == "") {
            inputField.text = "0";
        }
        switch (value)
        {
            case "ApogeeTextField":
                if (inputField.text == "")
                {
                    orbitCalculator.apogee = 0;
                    orbitCalculator.DrawOrbit();
                    break;
                }
                orbitCalculator.apogee = float.Parse(inputField.text);
                orbitCalculator.DrawOrbit();
                break;
            case "PerigeeTextField":
                if (inputField.text == "")
                {
                    orbitCalculator.perigee = 0;
                    orbitCalculator.DrawOrbit();
                    break;
                }
                orbitCalculator.perigee = float.Parse(inputField.text);
                orbitCalculator.DrawOrbit();
                break;
            case "InclinationTextField":
                if (inputField.text == "")
                {
                    orbitCalculator.inclination = 0;
                    orbitCalculator.DrawOrbit();
                    break;
                }
                orbitCalculator.inclination = float.Parse(inputField.text);
                orbitCalculator.DrawOrbit();
                break;
            case "RAANTextField":
                if (inputField.text == "")
                {
                    orbitCalculator.raan = 0;
                    orbitCalculator.DrawOrbit();
                    break;
                }
                orbitCalculator.raan = float.Parse(inputField.text);
                orbitCalculator.DrawOrbit();
                break;
            case "TrueAnomalyTextField":
                if (inputField.text == "")
                {
                    orbitCalculator.trueAnomaly = 0;
                    orbitCalculator.DrawOrbit();
                    break;
                }
                orbitCalculator.trueAnomaly = float.Parse(inputField.text);
                orbitCalculator.DrawOrbit();
                break;
            case "ArgOfPerigeeTextField":
                if (inputField.text == "")
                {
                    orbitCalculator.argOfPerigee = 0;
                    orbitCalculator.DrawOrbit();
                    break;
                }
                orbitCalculator.argOfPerigee = float.Parse(inputField.text);
                orbitCalculator.DrawOrbit();
                break;
        }
    }

}
