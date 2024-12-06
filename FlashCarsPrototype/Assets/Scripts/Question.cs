using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class Question : MonoBehaviour
{
    public Text subject;
    private static Dictionary<string, Dictionary<string, string[]>> questionSet;
    private void Start()
    {
        DisplaySelections();
        GenerateQuestions();
    }

    public static Dictionary<string, string[]> GetQuestionCategory(string sub, string diff)
    {
        if (sub == "Math")
        {
            if (diff == "Easy")
            {
                return questionSet["MathE"];
            } else
            {
                return questionSet["MathH"];
            }
        }
        else if (sub == "Science")
        {
            if (diff == "Easy")
            {
                return questionSet["ScienceE"];
            }
            else
            {
                return questionSet["ScienceH"];
            }
        }
        else if (sub == "English")
        {
            if (diff == "Easy")
            {
                return questionSet["EnglishE"];
            }
            else
            {
                return questionSet["EnglishH"];
            }
        }
        else if (sub == "History")
        {
            if (diff == "Easy")
            {
                return questionSet["HistoryE"];
            }
            else
            {
                return questionSet["HistoryH"];
            }
        }
        else
        {
            return null;
        }
    }
    private void DisplaySelections()
    {
        if (PlayerPrefs.HasKey("SelectedSubject") && PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            string selectedSubject = PlayerPrefs.GetString("SelectedSubject");
            string selectedDifficulty = PlayerPrefs.GetString("SelectedDifficulty");
            subject.text = $"Selected Subject: {selectedSubject}\nSelected Difficulty: {selectedDifficulty}";
        }
        else
        {
            subject.text = "No subject selected.";
        }
    }
    private void GenerateQuestions()
    {
        questionSet = new Dictionary<string, Dictionary<string, string[]>>();
        questionSet["MathE"] = new Dictionary<string, string[]>
        {
            {"What is the difference between the value of the digit 9 and the digit 4 in 9,432?", new[] {"8,600", "9,000" } },
            {"If a store has 324 apples and sells 178, how many are left?", new[] {"202", "146"} },
            {"What is 45 x 3?", new[] {"135", "120"} },
            {"Which fraction is greater: 3/4 or 4/3?", new[] {"3/4", "4/3"} },
            {"A rectangle has a length of 8 cm and a width of 4 cm. What is its perimeter?", new[] {"24 cm", "32 cm"} }
        };
        questionSet["MathH"] = new Dictionary<string, string[]>
        {
            {"Divide 4,872 by 12.", new[] {"406", "408"} },
            {"What is 2/3 x 3/4?", new[] {"1/3", "1/2"} },
            {"What is 12.45 + 9.87?", new[] {"22.32", "21.45"} },
            {"A rectangular prism has dimensions 5 cm by 3 cm by 4 cm. What is its volume?", new[] {"65 cubic cm", "60 cubic cm"} },
            {"What is the distance between (3, 4) and (6, 4) on a coordinate plane?", new[] {"3 units", "6 units"} }
        };
        questionSet["HistoryE"] = new Dictionary<string, string[]>
        {
            {"Which ocean is to the west of North America?", new[] {"Pacific Ocean", "Atlantic Ocean"} },
            {"Name one reason European settlers came to North America in the 1600s.", new[] {"Trade", "Religious freedom"} },
            {"Which direction is opposite North on a compass?", new[] {"South", "East"} },
            {"Name one artifact archaeologists study to learn about early Native Peoples.", new[] {"Clothes", "Stone tools"} },
            {"What was the name of the 1803 land purchase that doubled the size of the U.S.?", new[] {"Louisiana Purchase", "Alaska Purchase"} }
        };
        questionSet["HistoryH"] = new Dictionary<string, string[]>
        {
            {"What was the Boston Tea Party a protest against?", new[] {"British taxation", "Lack of independence"} },
            {"What is the purpose of checks and balances in the U.S. government?", new[] {"Make laws faster", "Prevent too much power"} },
            {"Name three major physical features in North America.", new[] {"Mississippi River, Rockies, Great Lakes", "Grand Canyon, Alps, Amazon"} },
            {"Who wrote the Declaration of Independence, and when?", new[] {"George Washington, 1775", "Thomas Jefferson, 1776"} },
            {"Why did European nations send explorers across the Atlantic?", new[] {"New trade routes and empires", "Gold mining"} }
        };
        questionSet["ScienceE"] = new Dictionary<string, string[]>
        {
            {"What are the three main states of matter?", new[] {"Solid, liquid, gas", "Solid, air, fire"} },
            {"What process allows plants to make food using sunlight?", new[] {"Respiration", "Photosynthesis"} },
            {"What force pulls objects to Earth?", new[] {"Gravity", "Magnetism"} },
            {"What is the layer of gases around Earth called?", new[] {"Stratosphere", "Atmosphere"} },
            {"What do we call animals that eat only plants?", new[] {"Herbivores", "Carnivores"} }
        };
        questionSet["ScienceH"] = new Dictionary<string, string[]>
        {
            {"What type of energy is stored in a battery?", new[] {"Chemical energy", "Electrical energy"} },
            {"What is the process by which water changes from gas to liquid?", new[] {"Evaporation", "Condensation"} },
            {"What is the term for animals eating both plants and animals?", new[] {"Omnivore", "Carnivore"} },
            {"What is the hottest layer of the Earth?", new[] {"Mantle", "Inner core"} },
            {"What is the role or job of an organism in its environment?", new[] {"Niche", "Habitat"} }
        };
    }
}
