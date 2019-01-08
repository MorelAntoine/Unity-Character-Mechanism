using UnityEditor;
using UnityEngine;

namespace CharacterMechanism.Normal.Attribute
{
    /// <inheritdoc/>
    /// <summary>
    /// Make the field read only in the inspector
    /// </summary>
    public sealed class ReadOnlyAttribute : PropertyAttribute
    {}

    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public sealed class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();
        }
    }
}
