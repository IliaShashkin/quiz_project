﻿namespace IdiomQuiz.Pages;

public sealed partial class Quiz
{
    private Idiom[] _idioms;
    private int _currentQuestionIdx;
    private int _correctAnswer;
    private bool _revealCorrectAnswer;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _currentQuestionIdx = 0;
        _correctAnswer = 0;
        _revealCorrectAnswer = false;

        LoadData();
    }

    private void LoadData()
    {
        string[] csvFile = IdiomData.Data.Split(Environment.NewLine);
        var idioms = new Idiom[csvFile.Length];
        for (int i = 1; i < csvFile.Length; i++)
        {
            string[] columns = csvFile[i].Split(';');
            idioms[i - 1] = new Idiom(columns[0], columns[1],columns[2..]);
            
        }
        Random.Shared.Shuffle(idioms);
        _idioms = idioms;
    }
    
}

public sealed class Idiom
{
    private readonly string _correctInterpretation;
    public string IdiomText { get; }
    public string[] Answers { get; }

    public Idiom(string idiom, string correctInterpretation, string[] incorrectInterpretations)
    {
        _correctInterpretation = correctInterpretation;
        IdiomText = idiom;
        Answers = ShuffleAnswers(correctInterpretation,incorrectInterpretations);
    }

    public bool IsCorrectAnswer(string answer) => answer == _correctInterpretation;

    private static string[] ShuffleAnswers(string correctInterpretation, string[] incorrectInterpretations)
    {
        string[] answers = [correctInterpretation, ..incorrectInterpretations];
        Random.Shared.Shuffle(answers);
        return answers;
    }
}
public static class IdiomData
{
    public const string Data = """
                               Idiom;Correct Interpretation;WrongInterpretation1;WrongInterpretation2;WrongInterpretation3
                               Ois hoib so wüd;It's not as bad as expected;It's twice as wild as expected;It's half as good as we thought;It's exactly as bad as expected
                               Hüft's nix schodt's a ned;Even if it doesn't help, at least it won't do any harm;If it doesn't help, it will harm you;It helps and harms equally;It will surely help and not harm
                               Ageh, scheiß di ned o;Don't be afraid;Go ahead, make a mess;Don't get angry;The toilet is clogged
                               Bessa ois wia a Sta am Schedl;It's not great, but it could be even worse;It's better than the best;It's as bad as it gets;It's worse than expected
                               Du beidlst am Watschnbam;You are straining my patience;You are climbing the wrong tree;You are missing the point;You are being very helpful
                               Du konnst ma an Schuach aufblosen;I don't care, get lost;You can tie my shoes;You can help me out;I lost my shoes
                               Es ist g'hupft wia g'hatscht;It doesn't make any difference;It's better to jump than to run;It's time to dance and sing;It's as good as it gets
                               A Lösung vo Zwöfi bis Mittog;The solution won't work for long;The solution is very easy to implement;The solution will last forever;The solution is perfect
                               Dafrorn sand scho vü, dastunga nu kana;We can stop airing out the room now, it's cold;Many have frozen here, but none have died;There are many people here, but no one is singing;We need to clean the room, it's dirty
                               Glei spüt's Granada;There's going to be trouble soon;We'll go to Spain;The music will start soon;The play is about to begin
                               Nägl mit Kepf mocha;Implementing a proper solution;Hitting somebody's head with nails;Implementing a sub-par solution;Painting portraits on fingernails
                               No, hawi d'Ehre;Being surprised;Now, I have the honor;Yes, I expected this;No, I decline the honor
                               Do spüt d'Musi;Be attentive, that is important;The orchester is playing here;It's quiet here;This is nonsense
                               In da Not frisst da Teife Fliagn;If there is no other option, we have to work with what we have;Flies are a valueable food source;In times of need, flies help us;Flies will eat the devil
                               Do host ka Leiwal;You don't stand a chance;You have a new shirt;You have no life;You are very lucky
                               I hob Mognleis;I'm nervous;I have stomach pain;I am hungry;I feel confident
                               Ned gschimpft is globt gnua;Not scolding you is praise enough;I'd never scold you;No news is bad news;Being scolded is high praise
                               Nur ned hudln;Don't do it in haste, take your time;Don't bother me now;Only do it quickly;Hurry up and finish
                               Budl di ned auf;Don't get upset about this;Dig yourself a hole;Get dressed quickly;Cheer up and smile
                               Wos da Baua ned kennt, frisst a ned;Not wanting to try a new dish;What the farmer doesn't know won't hurt him;Trying out new dishes;Products from the farmer's market are the best
                               Wer zoit schofft au;Whoever pays gets to tell the others what to do;Whoever pays also works;Who pays works the least;Those who work pay the most
                               Wos liegt des pickt;We are not going to renegotiate;What's lying around is sticky;Don't eat food from the floor;Needing to take a rest
                               Wos wiegt's des hods;We'll act according to the facts and not on personal feelings;What weighs more is better;The heavier it is, the harder it falls;Deciding on a gut feeling
                               Hau ma uns üba de Heisa;Let's go home;Let's build a new house;Let's fight over the houses;Let's meet at their house
                               Des hunzt;There is a problem;This dog;It's working perfectly;That helps a lot
                               Bisd heiratst is wieda guad;It will get better over time;It will get worse over time;This guy is very important;Marriage makes everything worse
                               Redt ma vo da Stözn, kummt de gonze Sau;When somebody enters the room you were just talking about;The waiter is bringing the food;Talking about dinner makes you hungry;When you talk about money, more comes
                               I hobs drawi;Being in a hurry;I have it with me;I can handle it;I'm in no hurry
                               Um's Oaschlecka;Fitting tightly with little wiggle room;Lick my backside;It's not fitting by a small bit;It's impossible to do
                               Liag mi ned au;Don't tell me lies;Don't lie down over there;Don't wake me up;I need to rest
                               Gemmas o;Let's get started;Let's go home;Let's give up;Let's wait here
                               Bist wo ogrennt?;Are you crazy/stupid?;Did you hurt yourself?;Do you like me?;Did you arrive already?
                               """;
}