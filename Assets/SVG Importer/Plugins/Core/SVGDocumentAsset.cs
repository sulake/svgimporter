

using UnityEngine;
using UnityEngine.Serialization;

using System.Collections;

namespace SVGImporter 
{
    public enum SVGError
    {
        None = 0,
        Syntax = 1,
        CorruptedFile = 2,
        ClipPath = 3,
        Symbol = 4,
        Image = 5,
        Mask = 6,
        Unknown = 7
    }

    public class SVGDocumentAsset : ScriptableObject {

        [FormerlySerializedAs("errors")]
        [SerializeField]
        protected SVGError[] _errors = default;
        public SVGError[] errors
        {
            get {
                return _errors;
            }
            set {
                _errors = value;
            }
        }

        [FormerlySerializedAs("svgFile")]
        [SerializeField]
        protected string _svgFile = default;
        public string svgFile
        {
            get {
#if UNITY_EDITOR
                if(string.IsNullOrEmpty(_svgFile))
                {
                    var svgAssetPath = UnityEditor.AssetDatabase.GetAssetPath(this);
                    var svgAssetImporter = UnityEditor.AssetImporter.GetAtPath(svgAssetPath);
                    return svgAssetImporter.userData;
                }
#endif
                return _svgFile;
            }
            set {
                _svgFile = value;
            }
        }

        [FormerlySerializedAs("title")]
        [SerializeField]
        protected string _title = default;
        public string title
        {
            get {
                return _title;
            }
            set {
                _title = value;
            }
        }

        [FormerlySerializedAs("description")]
        [SerializeField]
        protected string _description = default;
        public string description
        {
            get {
                return _description;
            }
            set {
                _description = value;
            }
        }

        public static SVGDocumentAsset CreateInstance(string svgFile, SVGError[] errors = null, string title = null, string description = null)
        {
            SVGDocumentAsset svgDocumentAsset = ScriptableObject.CreateInstance<SVGDocumentAsset>();
            svgDocumentAsset._description = description;
            svgDocumentAsset._title = title;
            svgDocumentAsset._svgFile = svgFile;
            svgDocumentAsset._errors = errors;
            return svgDocumentAsset;
        }
    }
}