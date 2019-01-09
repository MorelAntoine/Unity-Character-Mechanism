/*
** ReadOnlyAttribute.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 08 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

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
