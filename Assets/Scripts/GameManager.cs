using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<string>[] questions = new List<string>[5];
    private List<string> selectedQuestions = new();
    private int currentQuestionIndex = 0;
    private List<string> categoryNames = new List<string>()
    {
        "Пройдено",
        "Уявімо",
        "Щиро кажучи",
        "Особисте",
        "Інше"
    };
    private List<string> selectedCategories = new List<string>();

    public TMP_Text questionText;
    public TMP_Text categoryText;
    public Button nextButton;
    public Button randomButton;
    public Button ConfirmSettingsButton;
    public Button settingsButton;
    public GameObject card;
    public GameObject questionMark;
    public GameObject GamePanel;
    public GameObject SettingsPanel;
    public Toggle[] categoryToggles;

    void Start()
    {
        OpenSettings();
        ConfirmSettingsButton.onClick.AddListener(ConfirmSettings);

        questions[0] = new List<string>()
        {
            "Ким ви по-справжньому захоплюєтеся?",
            "Хто у вашому житті вас надихає?",
            "Найкращий комплімент, який ви коли-небудь отримували?",
            "Як ви познайомилися зі своїм найкращим другом/подругою?",
            "Чим насолоджуєтеся настільки, що забуваєте про час?",
            "Чи є люди, про яких ви часто згадуєте, незважаючи на те, що ви давно не спілкуєтеся?",
            "Розкажіть про найшаленішу вечірку, на якій ви коли-небудь бували?",
            "Якою була ваша перша робота?",
            "Чи розбивали вам коли-небудь серце?",
            "Яка ваша шкідлива звичка?",
            "Хто мав найбільший вплив на ваше дорослішання?",
            "Яким досягненням ви найбільше пишаєтеся у своєму житті?",
            "Яка книга найбільше вплинула на ваше життя?",
            "Що найбожевільніше ви коли-небудь робили?",
            "Ким ви хотіли стати, коли були дитиною?",
            "Яку активність чи спорт ви пробували у дитинстві і вам не вийшло?",
            "Які незручності вам доводилося терпіти з ввічливості?",
            "Найкраща порада, яку ви коли-небудь отримували?",
            "Якою була перша річ, яку ви купили за власні гроші?",
            "Яку з сімейних традицій ви б хотіли зберегти у майбутньому?",
            "Розкажіть про своє найкраще побачення?",
            "Від якої можливості заради кохання чи грошей ви відмовилися? Шкодуєте зараз?",
            "Розкажіть про своє найгірше побачення?"
        };

        questions[1] = new List<string>()
        {
            "Якщо б ви могли відвідати будь-яке місце у світі, де б воно було і чому?",
            "Якби ви могли змінити щось у своєму дитинстві, що б це було?",
            "Якщо б ви могли прожити до 90 років і після 30 років не старіти або тілом, або розумом, що б з цього ви обрали?",
            "Якщо б ви могли вчинити злочин без покарання, який би це був злочин?",
            "Якби у вас запитали, чому ви вважаєте себе доброю людиною, що б ви відповіли?",
            "Якби вам запропонували потрапити на обкладинку будь-якого журналу, то який би ви вибрали?",
            "Якщо б ви знали, що через рік раптово помрете, змінили б ви щось у своєму житті? Чому?",
        };

        questions[2] = new List<string>()
        {
            "Чи шкодуєте ви про щось, що не зробили, коли були молодші?",
            "Розкажіть про 3 найважливіші переломні моменти у вашому житті?",
            "Яке бажання ви не можете втілити через власну невпевненість або нерішучість?",
            "Якби ви могли змінити щось у своєму дитинстві, що б це було?",
            "Що, на вашу думку, кожен повинен зробити хоча б раз у житті?",
            "Що найбільш незаконне ви скоїли у своєму житті?",
            "Ваше найважче рішення, яке доводилось коли-небудь приймати?",
            "У що ви вірите, не маючи підтверджень про це?",
            "Які ваші особисті правила ви ніколи не порушуєте?",
            "Якби ви могли повернути час назад, що б ви змінили?",
            "Що є вашою таємною слабкістю, яку ви намагаєтеся приховати?",
            "Хибне перше враження, яке складається у людей про вас?",
            "Після смерті, ви б хотіли, щоб вас запам'ятали як..? ",
            "Якби у вас була можливість витратити велику суму грошей, але не на себе, на що б ви її витратили?",
            "Чого ви найбільше чекаєте протягом наступних 10 років?",
            "Якому стереотипу ви повністю відповідаєте?",
            "Чи складно вам зберігати чужі таємниці?",
            "Яку історію із життя ви не розповідаєте своїм батькам?",
            "Яку потребу ви задовольняєте у стосунках?"
        };

        questions[3] = new List<string>()
        {
            "Який мій подарунок тобі сподобався найбільше?",
            "Яка твоя мова любові (слова, подарунки, вчинки, обійми, увага...)?",
            "Назви три спільні риси з другою половинкою",
            "По шкалі від 1 до 10, як часто ти мене ревнуєш до інших?",
            "Чи є речі, які ти ніколи не пробачиш мені, якщо я це зроблю?",
            "Чим тобі запам'ятався наш перший поцілунок?",
            "Розкажи про свій улюблений спогад зі мною",
            "Ти коли-небудь хотів/ла мене образити?",
            "Скажи три твердження зі словом \"ми\"",
            "Що ти найбільше хотів/ла, щоб я тобі казав/ла під час нашої інтимної близькості?",
            "Хто з моїх друзів тобі ніколи не подобався?"
        };

        questions[4] = new List<string>()
        {
            "Ви б надали перевагу бути зіркою в команді, що програє, чи сидіти на лавці запасних у спортивній команді, що виграє?",
            "Ви б хотіли померти швидше за свого партнера чи пізніше?",
            "Який актор зіграв би вас у фільмі про ваше життя?",
            "Ви б надали перевагу бути найсмішнішою чи найрозумнішою людиною в кімнаті?",
            "Назвіть річ, яка подобається вам, але лякає інших людей?",
            "Ви надаєте перевагу котам чи собакам?",
            "Ви в кафе. Який з напоїв оберете?",
            "Ви б обрали виграти в лотерею 1 000 000 $ чи жити вдвічі довше?",
            "Якою була б ваша робота мрії, якби гроші не мали значення?",
            "Якою була ваша масштабніша покупка? Що саме це було?",
            "Ви б надали перевагу бути багатою людиною чи популярною?",
            "Кого з відомих людей вам доводилося зустрічати?",
            "Яка пора року відповідає вашій особистості найбільше?",
            "Який готель вам найбільше сподобався та чому?",
            "Яка ваша улюблена цитата?",
            "За яких «зірок» ви відчуваєте сором, коли бачите в новинах?",
            "Яка остання випадкова річ чи ситуація, що змусила вас посміхатися?",
            "Чим ви заповнюєте час, коли не можете заснути?",
            "Ви б швидше обрали закінчити життя однієї людини чи 100 цуценят і кошенят?",
            "Ваші добові ритми більше відповідають жайворонку (прокидаєтеся та лягаєте спати рано) чи сові (прокидаєтеся та лягаєте спати пізніше)?",
            "Для вас є щось занадто серйозне, над чим не можна жартувати?"
        };

        nextButton.onClick.AddListener(ShowNextQuestion);
        randomButton.onClick.AddListener(ShowRandomQuestion);
        settingsButton.onClick.AddListener(OpenSettings);

        ScaleElementWithDelay(2.0f, questionMark);
    }

    public void ActivateGamePanel()
    {
        Selectable[] selectables = GamePanel.GetComponentsInChildren<Selectable>();

        foreach (Selectable selectable in selectables)
        {
            selectable.interactable = true;
        }

        SettingsPanel.SetActive(false);
    }

    public void ConfirmSettings()
    {
        selectedQuestions.Clear();
        selectedCategories.Clear();

        for (int i = 0; i < categoryToggles.Length; i++)
        {
            if (categoryToggles[i].isOn)
            {
                selectedQuestions.AddRange(questions[i]);

                for (int j = 0; j < questions[i].Count; j++)
                {
                    selectedCategories.Add(categoryNames[i]);
                }
            }
        }

        if (selectedQuestions.Count != 0)
        {
            //Shuffle(selectedQuestions);

            currentQuestionIndex = 0;
            ShowQuestion(currentQuestionIndex);

            ActivateGamePanel();
        }
    }

    public void OpenSettings()
    {
        Selectable[] selectables = GamePanel.GetComponentsInChildren<Selectable>();

        foreach (Selectable selectable in selectables)
        {
            selectable.interactable = false;
        }

        SettingsPanel.SetActive(true);
    }

    private void ShowNextQuestion()
    {
        currentQuestionIndex = (currentQuestionIndex + 1) % selectedQuestions.Count;
        ShowQuestion(currentQuestionIndex);
    }

    private void ShowRandomQuestion()
    {
        currentQuestionIndex = Random.Range(0, selectedQuestions.Count);
        ShowQuestion(currentQuestionIndex);
    }

    private void ShowQuestion(int index)
    {
        questionText.text = selectedQuestions[index];
        categoryText.text = selectedCategories[index];

        // Rotate the card 90 degrees on the Y-axis (flipped state)
        card.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

        // Animate the card's rotation back to 0 degrees with a bounce effect
        LeanTween.rotateY(card, 0f, 0.5f)
            .setEase(LeanTweenType.easeOutBounce); // Use easeOutBounce for a bounce effect
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;

        }
    }

    private void ScaleElementWithDelay(float delay, GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1.1f, 1.1f, 1.1f), 0.5f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                // Scale down the element
                LeanTween.scale(obj, Vector3.one, 0.5f)
                    .setEase(LeanTweenType.easeInOutQuad)
                    .setOnComplete(() =>
                    {
                        // Wait for the delay and restart the cycle
                        LeanTween.delayedCall(delay, () =>
                        {
                            ScaleElementWithDelay(delay, obj);
                        });
                    });
            });
    }
}
