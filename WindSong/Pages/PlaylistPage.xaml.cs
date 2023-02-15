﻿// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WindSong.Midi;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WindSong.Pages;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
[INotifyPropertyChanged]
public sealed partial class PlaylistPage : Page
{

    public PlaylistPage()
    {
        this.InitializeComponent();
    }



    public ObservableCollection<MidiFolder> Playlist => MainPage.Current.Playlist;



    private void Button_Play_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            if (button.DataContext is MidiFileInfo info)
            {
                MainPage.Current.MidiPlayer.ChangeMidiFileInfo(info);
                MainPage.Current.MidiPlayer.Play();
            }
        }
    }


    [RelayCommand]
    private void LocateCurrentPlayingMidi()
    {
        var playing = MainPage.Current.MidiPlayer.MidiFileInfo;
        if (playing != null)
        {
            ListView_Playlist.SelectedItem = playing;
            ListView_Playlist.ScrollIntoView(playing, ScrollIntoViewAlignment.Leading);
        }
    }









}