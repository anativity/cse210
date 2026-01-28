using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }
public void HideRandomWords(int numberToHide)
    {
     int wordsHidden = 0;
     while (wordsHidden < numberToHide && !IsCompletelyHidden())
        {
            int index = _random.Next(0, _words.Count);
            Word word = _words[index];

            if (!word.IsHidden())
            {
                word.Hide();
                wordsHidden++;
            }
        }   
    }
public string GetDisplayText()
    {
        List<string> wordTexts = new List<string>();

        foreach (Word word in _words)
        {
            wordTexts.Add(word.GetDisplayText());
        }
        string scriptureText = string.Join(" ", wordTexts);
        return $"{_reference.GetDisplayText()}\n{scriptureText}";
    }

public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}