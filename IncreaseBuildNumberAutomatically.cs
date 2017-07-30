//SOURCE: https://gist.github.com/andrew-raphael-lukasik/36a30f0955d7cdc758e394dc4e7266bf
using System.Collections;

using UnityEngine;

using UnityEditor;
using UnityEditor.Build;


public class IncreaseBuildNumberAutomatically : IPreprocessBuild
{
    #region IPreprocessBuild implementation

    public void OnPreprocessBuild ( BuildTarget target , string path )
    {
        IncreaseBuildNumbers();
    }

    #endregion
    #region IOrderedCallback implementation

    public int callbackOrder { get { return 0; } }

    #endregion
    #region PRIVATE_METHODS

    static void IncreaseBuildNumbers ()
    {
        try
        {
            //update bundleVersion:
            //bundleVersion expected format is "1.0.0"
            string[] bundleVersionSplit = PlayerSettings.bundleVersion.Split( '.' );
            PlayerSettings.bundleVersion = bundleVersionSplit[ 0 ]+"."+bundleVersionSplit[ 1 ]+"."+( int.Parse( bundleVersionSplit[ 2 ] )+1 );

            //update buildNumber:
            PlayerSettings.macOS.buildNumber = ( int.Parse( PlayerSettings.macOS.buildNumber )+1 ).ToString();

            Debug.Log( "build#: "+PlayerSettings.macOS.buildNumber );
        }
        catch( System.Exception ex )
        {
            Debug.LogException( ex );
        }
    }

    #endregion
}