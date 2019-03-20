using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin.Essential_Demo
{
    public class VersionTrackingDemo : ContentPage
    {
        private Label title;
        private Label label_firstLaunch;
        private Label label_firstLaunchCurrent;
        private Label label_firstLaunchBuild;
        private Label label_currentVersion;
        private Label label_currentBuild;
        private Label label_previouosVersion;
        private Label label_previousBuild;
        private Label label_firstVersion;
        private Label label_firstBuild;
        private Label label_versionHistory;
        private Label label_buildHistory;

        public VersionTrackingDemo()
        {
            VersionTracking.Track();

            // First time ever launched application
            var firstLaunch = VersionTracking.IsFirstLaunchEver;

            // First time launching current version
            var firstLaunchCurrent = VersionTracking.IsFirstLaunchForCurrentVersion;

            // First time launching current build
            var firstLaunchBuild = VersionTracking.IsFirstLaunchForCurrentBuild;

            // Current app version (2.0.0)
            var currentVersion = VersionTracking.CurrentVersion;

            // Current build (2)
            var currentBuild = VersionTracking.CurrentBuild;

            // Previous app version (1.0.0)
            var previousVersion = VersionTracking.PreviousVersion;

            // Previous app build (1)
            var previousBuild = VersionTracking.PreviousBuild;

            // First version of app installed (1.0.0)
            var firstVersion = VersionTracking.FirstInstalledVersion;

            // First build of app installed (1)
            var firstBuild = VersionTracking.FirstInstalledBuild;

            // List of versions installed (1.0.0, 2.0.0)
            var versionHistory = VersionTracking.VersionHistory;

            // List of builds installed (1, 2)
            var buildHistory = VersionTracking.BuildHistory;

            title = new Label { Text = "This is a version tracking demo." };
            label_firstLaunch = new Label { Text = "firstLaunch: " + (firstLaunch == null ? "" : firstLaunch.ToString()) };
            label_firstLaunchCurrent = new Label { Text = "firstLaunchCurrent: " + (firstLaunchCurrent == null ? "" : firstLaunchCurrent.ToString()) };
            label_firstLaunchBuild = new Label { Text = "firstLaunchBuild: " + (firstLaunchBuild == null ? "" : firstLaunchBuild.ToString()) };
            label_currentVersion = new Label { Text = "currentVersion: " + (currentVersion == null ? "" : currentVersion.ToString()) };
            label_currentBuild = new Label { Text = "currentBuild: " + (currentBuild == null ? "" : currentBuild.ToString()) };
            label_previouosVersion = new Label { Text = "previousVersion: " + (previousVersion == null ? "" : previousVersion.ToString()) };
            label_previousBuild = new Label { Text = "previousBuild: " + (previousBuild == null ? "" : previousBuild.ToString()) };
            label_firstVersion = new Label { Text = "firstVersion: " + (firstVersion == null ? "" : firstVersion.ToString()) };
            label_firstBuild = new Label { Text = "firstBuild: " + (firstBuild == null ? "" : firstBuild.ToString()) };
            label_versionHistory = new Label { Text = "versionHistory: " + (versionHistory == null ? "" : String.Join(", ", versionHistory)) };
            label_buildHistory = new Label { Text = "buildHistory: " + (buildHistory == null ? "" : String.Join(", ", buildHistory)) };

            Content = new StackLayout
            {
                Children = {
                    title,  label_firstLaunch,label_firstLaunchCurrent,label_firstLaunchBuild, label_currentVersion,
                    label_currentBuild, label_previouosVersion, label_previousBuild,  label_firstVersion,
                    label_firstBuild,label_versionHistory,  label_buildHistory
                }
            };
        }
    }
}