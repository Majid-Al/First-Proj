using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public static class GameExtensions
{
    public static string FixFarsiText(string input)
    {
        System.Text.StringBuilder outputBuilder = new System.Text.StringBuilder();
        // Basic fix-up logic: reverse the string and add spaces for joining.
        char[] inputCharArray = input.ToCharArray();
        System.Array.Reverse(inputCharArray);
        outputBuilder.Append(inputCharArray);

        // Note: This won't handle contextual joining correctly—it simply reverses the string
        // Use a plugin or advanced algorithm for correct glyph positioning and joining

        return outputBuilder.ToString();
    }

}
