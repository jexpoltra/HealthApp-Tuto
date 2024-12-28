using UnityEditor;
using UnityEngine;
using static SettingsManager;

[CustomEditor(typeof(SettingsManager))]
public class CustomButtonForSettings : Editor
{
    public override void OnInspectorGUI()
    {
        // TARGET SCRIPT
        SettingsManager settings = (SettingsManager)target;

        // Styling for of the buttons for the in Game Action (e.g. next field)
        GUIStyle bigButtonStyle = new(GUI.skin.button)
        {
            fixedHeight = 35
        };

        // Draw the default inspector from the target script for any field that get added
        DrawDefaultInspector();



        // ---------- EXAMPLES -----------

        //if (GUILayout.Button("NAME_OF_YOUR_BUTTON", bigButtonStyle))
        //{
        //    settings.NAME_OF_FUNCTION_FROM_TARGET_SCRIPT();
        //}

        // Too create a Label
        // EditorGUILayout.LabelField("YOUR_LABEL_HERE", EditorStyles.boldLabel);

        // Generate fields with increment/decrement buttons
        // DrawIntFieldWithButtons("NAME_OF_YOUR_FIELD", ref settings.VARIABLE_NAME_IN_TARGET_SCRIPT);

        // Draw multiple choice button group for Gender selection
        // DrawMultipleChoiceButton("NAME_OF_YOUR_FIELD", ref settings.ENUM_INSTANCE_NAME_IN_TARGET_SCRIPT);

        // Draw float field with fine and coarse increment/decrement buttons for Avatar Scaling
        // DrawPreciseFloatWithButtons("Avatar Scaling", ref settings.AvatarScale, 0.001f, 0.01f);

        // Spacing between fields or buttons
        // EditorGUILayout.Space()
    }


    // Helper method to create an integer field with increment/decrement buttons
    private void DrawIntFieldWithButtons(string label, ref int field)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.Width(EditorGUIUtility.labelWidth));
        field = EditorGUILayout.IntField(field);

        if (GUILayout.Button("-", GUILayout.Width(30))) field--;  // Decrease button
        if (GUILayout.Button("+", GUILayout.Width(30))) field++;  // Increase button

        EditorGUILayout.EndHorizontal();
    }


    // Helper method to create a float field with fine and coarse increment/decrement buttons
    private void DrawPreciseFloatWithButtons(string label, ref float field, float smallStep, float largeStep)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.Width(EditorGUIUtility.labelWidth));
        field = EditorGUILayout.FloatField(field);

        // Adjustments with round-off to 3 decimal places
        if (GUILayout.Button("--", GUILayout.Width(30))) field = Mathf.Round((field - largeStep) * 1000f) / 1000f;
        if (GUILayout.Button("-", GUILayout.Width(30))) field = Mathf.Round((field - smallStep) * 1000f) / 1000f;
        if (GUILayout.Button("+", GUILayout.Width(30))) field = Mathf.Round((field + smallStep) * 1000f) / 1000f;
        if (GUILayout.Button("++", GUILayout.Width(30))) field = Mathf.Round((field + largeStep) * 1000f) / 1000f;

        EditorGUILayout.EndHorizontal();
    }


    // Helper method to create a button group for each option in an enum type
    private void DrawMultipleChoiceButton<T>(string label, ref T enumField, System.Action onChange = null) where T : System.Enum
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.Width(EditorGUIUtility.labelWidth));

        // Iterate through all enum values, creating a button for each
        foreach (string name in System.Enum.GetNames(typeof(T)))
        {
            var option = (T)System.Enum.Parse(typeof(T), name);

            // Toggle button, and apply change if the selection differs
            if (GUILayout.Toggle(enumField.Equals(option), name, "Button"))
            {
                if (!enumField.Equals(option))
                {
                    enumField = option;
                    onChange?.Invoke();  // Call onChange with the updated value
                }
            }
        }

        EditorGUILayout.EndHorizontal();
    }

}
