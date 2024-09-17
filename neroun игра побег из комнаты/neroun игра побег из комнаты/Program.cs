//игра побег из комнаты от NerouN
using System;
using System.Collections.Generic;

class Program
{
    // Переменные игры
    static bool doorUnlocked = false;
    static bool keyFound = false;
    static List<string> foundArtifacts = new List<string>();
    static string[] artifacts = { "статуэтка", "картина", "дневник", "часы" };
    static bool isGameRunning = true;

    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в игру 'Побег из комнаты'!");

        // Основной цикл игры
        while (isGameRunning)
        {
            Console.WriteLine("\nВы находитесь в комнате. Что вы хотите сделать?");
            Console.WriteLine("Доступные команды: осмотреть, взять, открыть дверь, выйти");

            // Чтение команды игрока
            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "осмотреть":
                    InspectRoom();
                    break;
                case "взять":
                    FindArtifact();
                    break;
                case "открыть дверь":
                    OpenDoor();
                    break;
                case "выйти":
                    isGameRunning = false;
                    Console.WriteLine("Вы вышли из игры.");
                    break;
                default:
                    Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");
                    break;
            }
        }
    }

    // Осмотреть комнату
    static void InspectRoom()
    {
        Console.WriteLine("Вы видите следующие артефакты в комнате:");
        foreach (var artifact in artifacts)
        {
            if (!foundArtifacts.Contains(artifact))
                Console.WriteLine($"- {artifact}");
        }
    }

    // Найти артефакт
    static void FindArtifact()
    {
        Console.WriteLine("Введите название артефакта, который хотите взять:");
        string artifact = Console.ReadLine().ToLower();

        if (Array.Exists(artifacts, a => a == artifact) && !foundArtifacts.Contains(artifact))
        {
            foundArtifacts.Add(artifact);
            Console.WriteLine($"Вы взяли {artifact}.");
        }
        else if (foundArtifacts.Contains(artifact))
        {
            Console.WriteLine("Этот артефакт уже найден.");
        }
        else
        {
            Console.WriteLine("Такого артефакта нет в комнате.");
        }

        // Проверка: все ли артефакты найдены
        if (foundArtifacts.Count == artifacts.Length && !keyFound)
        {
            keyFound = true;
            Console.WriteLine("Вы нашли все артефакты! Ключ появился в комнате.");
        }
    }

    // Открыть дверь
    static void OpenDoor()
    {
        if (!keyFound)
        {
            Console.WriteLine("Дверь закрыта. Вы не нашли ключ.");
        }
        else if (!doorUnlocked)
        {
            doorUnlocked = true;
            Console.WriteLine("Вы открыли дверь! Вы можете выйти из комнаты.");
        }
        else
        {
            Console.WriteLine("Вы уже открыли дверь! Побег завершен.");
            Console.WriteLine("Поздравляем! Вы успешно сбежали из комнаты!");
            isGameRunning = false;
        }
    }
}