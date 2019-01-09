using CharacterMechanism.Normal.System;
using UnityEditor;
using UnityEngine;

namespace CharacterMechanism.Normal.Editor
{
    /// <inheritdoc/>
    /// <summary>
    /// Custom editor for the ACharacterSystem script and his children
    /// </summary>
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ACharacterSystem), true)]
    public class ACharacterSystemEditor : UnityEditor.Editor
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        ////////////////////////////////////////////////
        ////////// Action State Configuration //////////

        private SerializedProperty _startActionState;

        //////////////////////////////////////////////
        ////////// Action State Information //////////
        
        private SerializedProperty _currentActionState;
        private SerializedProperty _previousActionState;
        
        ///////////////////////////////////
        ////////// Debug Setting //////////

        private SerializedProperty _shouldDisplayTransition;
        
        ////////////////////////////////////////
        ////////// Editor Information //////////

        private readonly string[] _basePropertyLabels = { "m_Script", "_currentActionState",
            "_previousActionState", "_startActionState", "_shouldDisplayTransition", "_inputInformation",
            "_inputInformation", "_triggerActionTransitions" };
        private int _toolbarIndex;
        private readonly string[] _toolbarLabels = { "Configuration", "Information", "Setting" };
        
        ////////////////////////////////////
        ////////// Editor Setting //////////

        protected const float SpaceBetweenField = 6f;
        
        ///////////////////////////////////////
        ////////// Input Information //////////

        private SerializedProperty _inputInformation;
        
        ///////////////////////////////////////////
        ////////// Trigger Configuration //////////

        private SerializedProperty _triggerActionTransitions;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        //////////////////////////
        ////////// Draw //////////

        /// <summary>
        /// Draw the children properties of a specialize ACharacterSystem
        /// </summary>
        private void DrawChildrenProperties()
        {
            DrawPropertiesExcluding(serializedObject, _basePropertyLabels);
        }
        
        /// <summary>
        /// Draw the configuration of an ACharacterSystem
        /// </summary>
        private void DrawConfiguration()
        {
            EditorGUILayout.LabelField("Action State", EditorStyles.boldLabel, null);
            EditorGUILayout.PropertyField(_startActionState, true, null);
            GUILayout.Space(SpaceBetweenField);
            EditorGUILayout.LabelField("Trigger", EditorStyles.boldLabel, null);
            EditorGUILayout.PropertyField(_triggerActionTransitions, true, null);
        }
        
        /// <summary>
        /// Draw the information of an ACharacterSystem
        /// </summary>
        private void DrawInformation()
        {
            EditorGUILayout.LabelField("Action State", EditorStyles.boldLabel, null);
            EditorGUILayout.PropertyField(_currentActionState, true, null);
            EditorGUILayout.PropertyField(_previousActionState, true, null);
            GUILayout.Space(SpaceBetweenField);
            EditorGUILayout.LabelField("Input Information", EditorStyles.boldLabel, null);
            DrawInputInformation();
        }

        /// <summary>
        /// Draw the input information of an ACharacterSystem
        /// </summary>
        private void DrawInputInformation()
        {
            var iterator = _inputInformation.Copy();
            var endProperty = iterator.GetEndProperty();
            SerializedProperty _childEndProperty = null;
            
            while ( (iterator.NextVisible(true)) && (!SerializedProperty.EqualContents(iterator, endProperty)) )
            {
                if ( SerializedProperty.EqualContents(iterator, _childEndProperty) )
                {
                    _childEndProperty = null;
                }
                if ( (iterator.hasVisibleChildren) && (_childEndProperty == null) )
                {
                    _childEndProperty = iterator.GetEndProperty();
                    EditorGUILayout.PropertyField(iterator, true, null);
                }
            }
        }
        
        /// <summary>
        /// Draw the setting of an ACharacterSystem
        /// </summary>
        private void DrawSetting()
        {
            EditorGUILayout.LabelField("Debug", EditorStyles.boldLabel, null);
            EditorGUILayout.PropertyField(_shouldDisplayTransition, true, null);
            GUILayout.Space(SpaceBetweenField);
        }

        /// <summary>
        /// Draw a toolbar containing the configuration, information and setting of an ACharacterSystem
        /// </summary>
        protected void DrawCharacterMechanismToolbar()
        {
            GUILayout.Space(SpaceBetweenField);
            _toolbarIndex = GUILayout.Toolbar(_toolbarIndex, _toolbarLabels);
            switch (_toolbarIndex)
            {
                case 1:
                    DrawInformation();
                    break;
                case 2:
                    DrawSetting();
                    break;
                default:
                    DrawConfiguration();
                    break;
            }
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, null);
        }
        
        /////////////////////////////////////
        ////////// Editor Callback //////////
        
        protected virtual void OnEnable()
        {
            _currentActionState = serializedObject.FindProperty("_currentActionState");
            _previousActionState = serializedObject.FindProperty("_previousActionState");
            _startActionState = serializedObject.FindProperty("_startActionState");
            _shouldDisplayTransition = serializedObject.FindProperty("_shouldDisplayTransition");
            _inputInformation = serializedObject.FindProperty("_inputInformation");
            _triggerActionTransitions = serializedObject.FindProperty("_triggerActionTransitions");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawCharacterMechanismToolbar();
            DrawChildrenProperties();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
