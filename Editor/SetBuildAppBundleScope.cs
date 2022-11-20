using System;
using UnityEditor;

namespace Kogane
{
    public sealed class SetBuildAppBundleScope : IDisposable
    {
        private readonly bool m_isAndroid;
        private readonly bool m_oldValue;

        public SetBuildAppBundleScope( BuildTarget buildTarget, bool value )
        {
            m_isAndroid = buildTarget == BuildTarget.Android;

            if ( !m_isAndroid ) return;

            m_oldValue = EditorUserBuildSettings.buildAppBundle;

            EditorUserBuildSettings.buildAppBundle = value;
        }

        public void Dispose()
        {
            if ( !m_isAndroid ) return;

            EditorUserBuildSettings.buildAppBundle = m_oldValue;
        }
    }
}