using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine.UI;
using ChartboostSDK;
using System.IO;

public class DBManager2 : MonoBehaviour
{

    private string connectionString;
    private List<Frases> frases = new List<Frases>();
    public Text phrase;
    int publicidad = 0;

    // Use this for initialization
    void Start ()
    {
        if ( (PlayerPrefs.GetInt("gameType") == 0) || (PlayerPrefs.GetInt("gameType") == 2) )
        {
            SmoothPhrases();
        }

        if ((PlayerPrefs.GetInt("gameType") == 1) || (PlayerPrefs.GetInt("gameType") == 2))
        {
            HardPhrases();
        }

        PickFrase();
    }

    public void PickFrase()
    {
        //el anuncio aparecerá cada 4 veces
        //primero incrementamos el contador
        if (! PlayerPrefs.GetString("noAds").Equals("NO") )
        {
            publicidad++;
        }
        //si el igual a 5 volverá a empezar y enseñamos los popups
        if (publicidad == 5)
        {
            publicidad = 0;
            Chartboost.cacheInterstitial(CBLocation.Default);
            Chartboost.showInterstitial(CBLocation.Default);
        }

        if (frases.Count != 0)
        {
            System.Random rnd = new System.Random();
            int i = rnd.Next(1, frases.Count + 1);

            if (PlayerData.playerData.languaje == 0)
            {
                phrase.text = "I have never . . . \n" + frases[i].textEN;
            }
            else if (PlayerData.playerData.languaje == 1)
            {
                phrase.text = "Yo nunca . . . \n" + frases[i].textSP;
            }
                
            frases.Remove(frases[i]);
        }
        else
        {
            if (PlayerData.playerData.languaje == 0)
            {
                phrase.text = "We are sorry \n we run out of phrases";
            }
            else if (PlayerData.playerData.languaje == 1)
            {
                phrase.text = "Lo sentimos \n No hay mas frases que mostrar";
            }
            
        }
        
    }

    public void SmoothPhrases ()
    {
        frases.Add(new Frases(1, "he meado en la calle mientra había gente mirando", "peed on the strees whereas people looked at me", 0, 0));
        frases.Add(new Frases(2, "he perdido la virginidad cuando era menor de edad", "lost my virginity when I was under age", 0, 0));
        frases.Add(new Frases(3, "he dicho las damas primero solo para mirarle el culo", "said ladies first just in order to stare at her ass", 0, 0));
        frases.Add(new Frases(4, "me he enamorado de un profesor", "fallen in love with a teacher", 0, 0));
        frases.Add(new Frases(5, "he sufrido un atraco", "suffered a robbery", 0, 0));
        frases.Add(new Frases(6, "he suspendido el exámen de conducir", "failed the driving test", 0, 0));
        frases.Add(new Frases(7, "he vomitado mientras estaba borracho", "thrown up while I was drunk", 0, 0));
        frases.Add(new Frases(8, "he querido participar en gran hermano", "wanted to join big brother", 0, 0));
        frases.Add(new Frases(9, "Me ha gustado una telenovela", "Liked a soap opera", 0, 0));
        frases.Add(new Frases(10, "Me he enamorado de alguien por internet", "Fell in love with someone over the internet", 0, 0));
        frases.Add(new Frases(11, "He intentado hacer dibujos en el suelo o la pared con mi meada", "tried to draw in the wall or the floor whereas I was pissing", 0, 0));
        frases.Add(new Frases(29, "He visto una peli porno", "Watch a porn movie", 0, 0));
        frases.Add(new Frases(30, "Me he metido las manos en el bolsillo para tocarme mis partes", "Introduced my hands on the pocket in order to touch my pennis", 0, 0));
        frases.Add(new Frases(31, "Me la he medido", "mesured my pennis", 0, 0));
        frases.Add(new Frases(32, "me he levantado sin acordarme de lo que he hecho la noche anterior", "I woke up without remembering what I did last night", 0, 0));
        frases.Add(new Frases(33, "Me he arrepentido de ir a la cama con alguien", "regreted to have sex with someone", 0, 0));
        frases.Add(new Frases(35, "he mentido jugando al yo nunca", "lied playing i have never", 0, 0));
        frases.Add(new Frases(36, "he dudado sobre mi sexualidad", "doubted about my heterosexuality", 0, 0));
        frases.Add(new Frases(37, "me he rascado el culo y me he olido los dedos", "scratched my ass and I have smelled my fingers after that", 0, 0));
        frases.Add(new Frases(38, "he bailado sin música mientras estaba borracho", "danced without music whereas I was drunk", 0, 0));
        frases.Add(new Frases(39, "me han echado de un bar por liarla parda", "got kicked out of a bar for being very drunk", 0, 0));
        frases.Add(new Frases(40, "me he tirado un pedo en la bañera y he visto como salía la burbujita", "farted in the shower and I have seen how the bubble came out", 0, 0));
        frases.Add(new Frases(41, "me he hecho fotos desnudo", "took naked photos of me", 0, 0));
        frases.Add(new Frases(46, "me he liado con un alguien muy muy feo/a", "kissed someone very ugly", 0, 0));
        frases.Add(new Frases(47, "he pillado a mis padres en plena acción", "caught my parents whereas they were having sex", 0, 0));
        frases.Add(new Frases(49, "he fumado mariguana", "smoked weed", 0, 0));
        frases.Add(new Frases(57, "he escrito SOY GAY en el estado de facebook de un amigo", "wrote on the facebook state of a friend I AM GAY", 0, 0));
        frases.Add(new Frases(58, "he ido borracho a clase", "went to classes being drunk", 0, 0));
        frases.Add(new Frases(60, "he hecho topless", "done topless", 0, 0));
        frases.Add(new Frases(61, "he ido a una playa nudista solo para ver al personal", "went to a nude beach just for watching people", 0, 0));
        frases.Add(new Frases(62, "he pasado más de un día sin ducharme", "stayed more than one day without showering me", 0, 0));
        frases.Add(new Frases(63, "he fingido que meaba en un baño público solo para quedar bien", "pretended to pee in a public toilet when I was not able to", 0, 0));
        frases.Add(new Frases(66, "me quedé sin papel higiénico en el baño", "run out of higienic paper in the toilet", 0, 0));
        frases.Add(new Frases(67, "me he empalmado o excitado mirando un videoclip", "got horny watching a music video", 0, 0));
        frases.Add(new Frases(69, "he revisado el papel higiénico después de cagar", "supervised the higienic paper after pooing", 0, 0));
        frases.Add(new Frases(72, "me he sentido atraido por un dibujo animado", "felt atracted by a cartoon", 0, 0));
        frases.Add(new Frases(74, "me he tirado un pedo debajo de las sábanas", "farted inside the bed", 0, 0));
        frases.Add(new Frases(75, "me he tirado un pedo y luego me he ido por que olía mal", "farted and went away after that because it smelled bad", 0, 0));
        frases.Add(new Frases(76, "me he sentido atraido por el presidente del gobierno", "thought that the president of the government was hot", 0, 0));
        frases.Add(new Frases(77, "he salido de fiesta hasta las 7 de la mañana", "partied till 3 AM", 0, 0));
        frases.Add(new Frases(78, "he mirado hacia abajo para que el profesor no me saque al encerado", "looked another way so the profesor doesn't pick me for going to the blackboard", 0, 0));
        frases.Add(new Frases(79, "me he perdido borracho", "got lost when I was drunk", 0, 0)); 
        frases.Add(new Frases(86, "he estado enamorado", "been in love", 0, 0));
        frases.Add(new Frases(87, "he tenido novio o novia", "had a boyfriend or girlfriend", 0, 0));
        frases.Add(new Frases(88, "he visto dragon ball", "watch dragon ball", 0, 0));
        frases.Add(new Frases(89, "he orinado en una piscina", "peed in a pool", 0, 0));
        frases.Add(new Frases(91, "miré como mis padres eran asesinados mientras me salía una cicatriz en la frente en forma de rayo", "looked how my parents died whereas one scar with the shape of a thunder appeared in my forehead", 0, 0));
        frases.Add(new Frases(92, "he olido un condón", "smelled a condom", 0, 0));
        frases.Add(new Frases(93, "supe hacer raíces cuadradas", "knew how to solve square roots", 0, 0));
        frases.Add(new Frases(96, "he perdido puntos del carnét de conducir", "got fined for bad driving", 0, 0));
        frases.Add(new Frases(97, "he hecho equilibrismos para mear dentro de la taza del váter", "tried to point my pennis so the pee can be inside the toilet", 0, 0));
        frases.Add(new Frases(98, "he tocado el pene de otro hombre", "touched the penis of another man", 0, 0));
        frases.Add(new Frases(99, "he cantado en la calle mientras escuchaba mi canción favorita", "sang in the street whereas I was hearing my favourite song", 0, 0));
        frases.Add(new Frases(100, "he bailado desnudo/a frente al espejo", "danced naked in front of the mirror", 0, 0));
        frases.Add(new Frases(104, "he creido en dios", "believed in god", 0, 0));
        frases.Add(new Frases(105, "he ido a misa", "prayed for the church", 0, 0));
        frases.Add(new Frases(106, "he jugado a papás y a mamás de pequeño", "played to be a mather or father when I was a kid", 0, 0));
        frases.Add(new Frases(107, "he sido delegado de clase", "been student representative", 0, 0));
        frases.Add(new Frases(108, "he repetido un curso en el instituto", "repited a year in the highschool", 0, 0));
        frases.Add(new Frases(109, "he visto los simpsong mientras comía", "watch the simpsongs whereas I was eating", 0, 0));
        frases.Add(new Frases(110, "he pensado que Lady Gaga tenía pene", "thought that Lady Gaga had a penis", 0, 0));
        frases.Add(new Frases(111, "me he puesto un nombre ridículo en el messenger", "had a ridiculous name in messenger", 0, 0));
        frases.Add(new Frases(112, "me han puesto un mote", "had a nickname", 0, 0));
        frases.Add(new Frases(113, "he tenido un blog personal", "had a personal blog", 0, 0));
        frases.Add(new Frases(114, "he saludado a alguien sin tener ni idea de quién es", "said hello to someone without remembering who was that person", 0, 0));
        frases.Add(new Frases(115, "he mirado en el armario por si había algo más escondido", "looked inside the closet just in case I find something else", 0, 0));
        frases.Add(new Frases(131, "he visto un tutorial de un latino en youtube", "watch a tutorial of an assian guy in youtube", 0, 0));
        frases.Add(new Frases(132, "he visto un video de chinos en youtube", "watched a weird video about japanese people", 0, 0));
        frases.Add(new Frases(133, "me he dormido en clase", "fell sleep in class", 0, 0));
        frases.Add(new Frases(134, "he viajado a Francia", "travelled to France", 0, 0));
        frases.Add(new Frases(135, "he viajado a Italia", "travelled to Italy", 0, 0));
        frases.Add(new Frases(136, "he dormido en un banco público", "slept on a public bench", 0, 0));
        frases.Add(new Frases(137, "he odiado un grupo de Whatsapp", "hated a Whatsapp/facebook chat group", 0, 0));
        frases.Add(new Frases(138, "he jugado a otros juegos de AdanzApps", "played another AdanzApps games", 0, 0));
        frases.Add(new Frases(139, "he hecho novillos", "pretended to be ill in order to don't go to classes", 0, 0));
        frases.Add(new Frases(140, "he necesitado dormir con un peluche", "needed to sleep with a tedy bear", 0, 0));
        frases.Add(new Frases(151, "he puesto una lavadora", "used the whashingmachine for cleaning my own clothes", 0, 0));
        frases.Add(new Frases(152, "he ido al baño y no me he lavado las manos después", "used the toilet and I didn't wash my hands after that", 0, 0));
        frases.Add(new Frases(153, "me he tirado un pedo cuando tenia diarrea ... Y me equivoqué!", "farted cause I thought that I was alone ... but i was wrong!", 0, 0));
        frases.Add(new Frases(154, "me he tirado un pedo y pensaba que no iba a sonar mucho ... pero no!", "farted cause I thought that I was not going to be very noisy ... but I was wrong!", 0, 0));
        frases.Add(new Frases(155, "me he tirado un pedo y le he hechado la culpa a otro", "farted and I blamed another person", 0, 0));
        frases.Add(new Frases(156, "he visto titanic", "watch titanic", 0, 0));
        frases.Add(new Frases(157, "he visto star wars", "watch star wars", 0, 0));
        frases.Add(new Frases(160, "he meado en la ducha igual que Mercedes Milá", "peed in the shower and I felt very good after that", 0, 0));
        frases.Add(new Frases(161, "he cantado en la ducha", "sang in the shower", 0, 0));
        frases.Add(new Frases(163, "he jugado al World of Wracraft", "played World of Wracraft", 0, 0));
        frases.Add(new Frases(164, "he jugado al Candy crush", "played Candy crush", 0, 0));
        frases.Add(new Frases(165, "he jugado algún juego de Mario Bross", "played any game of Mario Bross", 0, 0));
        frases.Add(new Frases(166, "he cantado en un Karaoke", "sang in a Kararoke", 0, 0));
        frases.Add(new Frases(167, "he dicho No vuelvo a beber mientras estaba de resaca", "said. I am not going to drink anymore whereas I had a hungover", 0, 0));
        frases.Add(new Frases(168, "he dicho: esta noche salgo de trankis ... pero no!", "said: I am not going to get very drunk tonight ... but in the end no!", 0, 0));
        frases.Add(new Frases(175, "he entrado en facebook mientras estaba borracho", "entered in facebook whereas I was drunk", 0, 0));
        frases.Add(new Frases(176, "he hecho como que no estaba borracho delante de mis padres", "acted like I was not drunk in fron of my parents", 0, 0));
        frases.Add(new Frases(177, "le he escrito a mi ex mientras estaba borracho", "texted my ex whereas I was drunk", 0, 0));
        frases.Add(new Frases(178, "he dicho ninguna tonería mientras estaba borracho", "said any stupid thing whereas I was drunk", 0, 0));
        frases.Add(new Frases(179, "baile como si no huviera mañana mientras estaba borracho", "danced like a crazy person because I was drunk", 0, 0));
        frases.Add(new Frases(182, "he visto salvame deluxe", "watch the program named real housewifes", 0, 0));
        frases.Add(new Frases(183, "he votado al presidente del gobierno", "voted for the president of the government", 0, 0));
        frases.Add(new Frases(184, "me he quedado con cara de imbecil mientras me cantaban cumpleaños feliz", "made a stupid face whereas my family sang happy birthday", 0, 0));
        frases.Add(new Frases(188, "he mirado anime", "watch anime", 0, 0));
        frases.Add(new Frases(189, "he ido a un evento friki", "went to a freak event", 0, 0));
        frases.Add(new Frases(194, "he preferido al señor de los anillos antes que Harry Potter", "prefered the lord of the rings rather than Harry Potter", 0, 0));
        frases.Add(new Frases(195, "he visto crespúsculo", "watched twilight", 0, 1));
        frases.Add(new Frases(196, "he preferido que gane el Madrid antes que el Barsa", "prefered the football team Madrid rather than Barcelona", 0, 0));
        frases.Add(new Frases(197, "he preferido quedarme a jugar a un videojuego antes que salir de fiesta", "prefered to play a videogame rather than going out in a party", 0, 0));
        frases.Add(new Frases(202, "he pensado que las mujeres son muy retorcidas", "thought that women are very tricky", 0, 0));
        frases.Add(new Frases(203, "he pensado que las mujeres son muy manipuladoras", "thought that women are very manipulative", 0, 0));
        frases.Add(new Frases(204, "he pensado que los hombres son muy simples", "thought that men are very simple", 0, 0));
        frases.Add(new Frases(205, "he pensado que los hombres son muy pervertidos", "thought that men are very pervert", 0, 0));
        frases.Add(new Frases(209, "he pensado que me estaba tirando un pedo ... pero había algo más!", "thought that I was going to fart ... but in the end it was something else!", 0, 0));
        frases.Add(new Frases(210, "he querido salir del agua por que estaba empalmado", "wanted to get out of the watter because my penis was too high", 0, 0));
        frases.Add(new Frases(212, "me he pedido un cup of café con leche in the plaza mayor!", "asked for a cup of café con leche in the plaza mayor (by Ana botella))", 0, 0));
        frases.Add(new Frases(213, "he mezclado ácido clorídrico con sulfato de ... vamos que la he liado parda!", "created a mess whereas I was cooking", 0, 0));
        frases.Add(new Frases(214, "he capturado a todos los pokémon en el rojo azul y amarillo", "caught all pokemon in red and blue", 0, 0));
        frases.Add(new Frases(215, "he dibujado un pene mientras estaba aburrido en clase", "drawn a penis whereas I was boring", 0, 0));
        frases.Add(new Frases(143, "dije te quiero sin sentirlo", "said I love you without feeling it", 1, 0));
        frases.Add(new Frases(144, "he fingido que tonteaba con alguien para dar celos", "pretended to flirt with someone in order to make him/her feel jelous", 1, 0));
        frases.Add(new Frases(150, "he hecho la cobra a nadie", "denied a kiss", 1, 0));

        frases.Add(new Frases(212, "He tenido una relación a distancia", "had a long distance relationship", 1, 0));
        frases.Add(new Frases(213, "He querido disfrazarme de pene o vagina", "wanted to disguise myself as a penis or vagina", 1, 0));
        frases.Add(new Frases(214, "He enseñado las tetas en un concierto", "taught the tits in a concert", 1, 0));
        frases.Add(new Frases(220, "He notado la erección de un chico al abrazarlo", "I have wanted to disguise myself as a penis or vagina", 1, 0));
        frases.Add(new Frases(221, "He examinado los mocos después de somarme para ver que tal estaban", "I have wanted to disguise myself as a penis or vagina", 1, 0));
        frases.Add(new Frases(222, "He robado en un supermercado", "Have stolen in a supermarket", 1, 0));
        frases.Add(new Frases(223, "Me importaría montármelo con otra chica", "would care to fuck with another girl", 1, 0));
        frases.Add(new Frases(224, "He dicho que soy lesbiana o gay para quitarme de encima a alguien", "Said I'm a lesbian or gay to get rid of someone", 1, 0));
        frases.Add(new Frases(225, "He llorado por amor", "Cried for love", 1, 0));
        frases.Add(new Frases(233, "He fumado mariguana", "smoked marijuana", 1, 0));
    }

    public void HardPhrases ()
    {
        frases.Add(new Frases(12, "Me he masturbado pensando en un profesor o profesora", "jerked of thinking of a teacher", 1, 0));
        frases.Add(new Frases(13, "Me han pillado follando", "got caught fuking", 1, 0));
        frases.Add(new Frases(14, "He follado en un lugar publico", "Had sex in public", 1, 0));
        frases.Add(new Frases(15, "He sido infiel", "been unfaithful", 1, 0));
        frases.Add(new Frases(16, "He tenido sexo con mi ex", "had sex with my ex-boyfriend/ex-girlfriend", 1, 0));
        frases.Add(new Frases(17, "Me han pillado masturbándome", "got caught masturbating", 1, 0));
        frases.Add(new Frases(18, "Me follaría a la madre o al padre en un amigo/a", "would have sex with the mother or father of a friend", 1, 0));
        frases.Add(new Frases(19, "Follaría con alguien de los presentes", "would have sex with anybody drinking here", 1, 0));
        frases.Add(new Frases(20, "He desvirgado a alguien", "had sex with a virgin", 1, 0));
        frases.Add(new Frases(21, "Me he masturbado en la ducha", "masturbated in the shower", 1, 0));
        frases.Add(new Frases(22, "He follado en una cama que no era la mía", "had sex in a bed that was not mine", 1, 0));
        frases.Add(new Frases(23, "Me he quedado enbarazada o he dejado embarazada a alguien", "been pegnant or I have never left someone pregnant", 1, 0));
        frases.Add(new Frases(24, "He follado en un baño publico", "had sex in a public toilet", 1, 0));
        frases.Add(new Frases(25, "He entrado en un puticlub", "entered in a whorehouse", 1, 0));
        frases.Add(new Frases(26, "He pagado por sexo", "paid for having sex", 1, 0));
        frases.Add(new Frases(27, "He propuesto un trío / me han propuesto un trío", "wanted to have a threesome or someone wanted to have a threesome with me", 1, 0));
        frases.Add(new Frases(28, "me gustaría tener relacciones sexuales con un actor/ actriz porno", "want to have sex with a pron actor/actress", 1, 0));
        frases.Add(new Frases(34, "He tenido relaciones sexuales en un coche", "had sex in a car", 1, 0));
        frases.Add(new Frases(42, "me he besado con alguien de los aquí presentes", "kissed anyone that is playing this game", 1, 0));
        frases.Add(new Frases(43, "me he olvidado de haber follado con alguien en una noche", "forgot to have sex with someone in one night", 1, 0));
        frases.Add(new Frases(44, "me he masturbado mas de tres veces en un día", "marsturbated more than three times in a day", 1, 0));
        frases.Add(new Frases(45, "he besado a alguien de mi mismo sexo", "kissed someone of the same sex", 1, 0));
        frases.Add(new Frases(48, "he dado / me han dado por el culo", "fucked in the ass /they fucked me in the ass", 1, 0));
        frases.Add(new Frases(50, "he besado a alguien sin conocerlo", "kissed someone without knowing him/her", 1, 0));
        frases.Add(new Frases(51, "he follado con alguien sin saber su nombre", "has sex with someone without knowing his/her name", 1, 0));
        frases.Add(new Frases(52, "me he masturbado", "marturbated myself", 1, 0));
        frases.Add(new Frases(53, "he visto porno mientras me masturbaba", "watched porn whereas I masturbated myself", 1, 0));
        frases.Add(new Frases(54, "he visto porno del sexo que no me gusta solo por curiosidad", "watched porn for the sex that I don't like, just for curiosity", 1, 0));
        frases.Add(new Frases(55, "me correría viendo a dos lesbianas magrearse", "would get cummed watching two lesbians kissing", 1, 0));
        frases.Add(new Frases(56, "he hecho el amor en la calle", "had sex in the street", 1, 0));
        frases.Add(new Frases(59, "he jugado al strip poker", "played strip poker", 1, 0));
        frases.Add(new Frases(64, "he entrado a chatear en el chatroulette", "entered in the website chatroulette", 1, 0));
        frases.Add(new Frases(65, "he hecho un striptease en público", "made an striptease in public", 1, 0));
        frases.Add(new Frases(68, "me he empalmado o excitado en clase", "turned on when I was in class", 1, 0));
        frases.Add(new Frases(70, "he tenido relaciones sexuales en el cine", "had sex in the cinema", 1, 0));
        frases.Add(new Frases(71, "he dudado sobre mi sexualidad", "doubdted about my sexuality", 1, 0));
        frases.Add(new Frases(73, "he visto porno hentay", "watch hentay porn", 1, 0));
        frases.Add(new Frases(81, "me he masturbado pensando en alguien conocido", "masturbated myself thinking on someone that I knew in person", 1, 0));
        frases.Add(new Frases(82, "he besado a alguien", "kissed anyone", 1, 0));
        frases.Add(new Frases(83, "he intentado chupármela a mi mismo", "tried to suck my own cock", 1, 0));
        frases.Add(new Frases(84, "me he levantado empalmado sin saber por que", "work up spliced without knowing why", 1, 0));
        frases.Add(new Frases(85, "me he besado con algún familiar", "kissed anyone from my family", 1, 0));
        frases.Add(new Frases(90, "me he preguntado como se masturban las mujeres", "wondered how women masturbate themselves", 1, 0));
        frases.Add(new Frases(94, "he chupado unas tetas planas", "I've never sucked small tits", 1, 0));
        frases.Add(new Frases(95, "he tenido sexo con un oriental", "has sex with asian people", 1, 0));
        frases.Add(new Frases(101, "he tenido relacciones sexuales con un gordo/a", "had sex with a fat boy or girl", 1, 0));
        frases.Add(new Frases(102, "he pensado en otra persona practicando sexo", "thought on another person whereas I was having sex", 1, 0));
        frases.Add(new Frases(103, "la metí por el agujero que no era mientras tenía relaciones sexuales", "introduced my penis in the wrong hole whereas I was hiving sex", 1, 0));
        frases.Add(new Frases(116, "me he resistido a eyacular en una semana", "been without ejaculating more than one week", 1, 0));
        frases.Add(new Frases(117, "he mentido acerca del tamaño de mi pene", "lied about the size of my penis", 1, 0));
        frases.Add(new Frases(118, "he mentido acerca de la talla de mis tetas", "lied about the size of my boobs", 1, 0));
        frases.Add(new Frases(119, "he presumido de haber follado", "had presumed for having sex", 1, 0));
        frases.Add(new Frases(120, "me he masturbado con la ayuda de una sandía", "masturbated myself using a watermelon", 1, 0));
        frases.Add(new Frases(121, "he participado en una orgía", "participated in an orgy", 1, 0));
        frases.Add(new Frases(122, "he tenido relacciones sexuales con algunos de nosotros", "had sex with any of us", 1, 0));
        frases.Add(new Frases(123, "he tenido un pensamiento zoofílico (bebe si lo estás pensando ahora))", "had a zoofilic thought (drink if you are thinking on it now))", 1, 0));
        frases.Add(new Frases(124, "violaría a un caballo a cambio de un millón de euros", "would violate a horse if I would get a million euros on exchange", 1, 0));
        frases.Add(new Frases(125, "he masturbado a alguien / me han masturbado con las dos manos a la vez", "masturbated someone / someone masturbated me with both hands", 1, 0));
        frases.Add(new Frases(126, "me he depilado mis partes íntimas", "shaved up my testicles / pussy", 1, 0));
        frases.Add(new Frases(127, "he practicado sexo encima de la lavadora", "had sex on top of the washmachine", 1, 0));
        frases.Add(new Frases(129, "he calentado a alguien para que me inviten a una copa", "seduced someone so he can invite me to a glass", 1, 0));
        frases.Add(new Frases(130, "he tratado de ligar con un profesor para que me subiera la nota", "tried to seduce a profesor in order to get a better mark", 1, 0));
        frases.Add(new Frases(141, "he golpeado el teclado del ordenador con el pene", "kicked the keyboard of my PC with my penis", 1, 0));
        frases.Add(new Frases(142, "me ha puesto cachondo alguien de clase", "liked in a sexual way anyone from my class", 1, 0));  
        frases.Add(new Frases(145, "me he corrido en las tetas de una chica", "had cummed on the boobs of a girl", 1, 0));
        frases.Add(new Frases(146, "he recibido sexo anal ... de un pokémon!", "had anal sex ... from a pokemon!", 1, 0));
        frases.Add(new Frases(147, "me han ofrecido drogas", "been offed drugs", 1, 0));
        frases.Add(new Frases(148, "he practicado sexo virtual", "had virtual sex", 1, 0));
        frases.Add(new Frases(149, "me he puesto cachondo/a leyendo un libro", "got horny by reading a book", 1, 0));
        frases.Add(new Frases(158, "he besado a un chico y me gustó", "kissed a boy and I liked it", 1, 0));
        frases.Add(new Frases(159, "he besado a una chica y me gustó", "kissed a girl and I liked it", 1, 0));
        frases.Add(new Frases(162, "me han masturbado", "been masturbated by someone", 1, 0));
        frases.Add(new Frases(170, "me he pillado un coma etílico", "Had to go to the hospital because I drank too much", 1, 0));
        frases.Add(new Frases(171, "he tenido un folla-amigo/a", "Had a friend with benefits", 1, 0));
        frases.Add(new Frases(172, "he tenido mas de un folla-amigo/a al mismo tiempo", "Had more than 1 friend with benefits at the same time", 1, 0));
        frases.Add(new Frases(173, "he intentado follarme a la almohada", "tried to have sex with my pillow", 1, 0));
        frases.Add(new Frases(180, "me he besado con mi mejor amigo/a", "kissed my best friend", 1, 0));
        frases.Add(new Frases(181, "me ha gustado mi primo/a", "liked my counsin in a sexual way", 1, 0));
        frases.Add(new Frases(185, "he entrado en redtube", "entered in redtube", 1, 0));
        frases.Add(new Frases(186, "he entrado en youporn.com", "entered in youporn.com", 1, 0));
        frases.Add(new Frases(187, "he entrado en un sitio de citas online", "entered in a web page for online dating", 1, 0));
        frases.Add(new Frases(190, "he pensado que me gusta el sadomasokismo después de ver 50 sombras de Grey", "thought that I like S&M after watching fifty shades of Grey", 1, 0));
        frases.Add(new Frases(191, "me han pegado un cachete en el culo mientras follaba y me ha gustado", "received a knock whereas I was having sex and I liked it", 1, 0));
        frases.Add(new Frases(192, "me ha gustado el porno de disfraces", "liked porn with costumes", 1, 0));
        frases.Add(new Frases(193, "he usado las esposas de manera sexual", "used the handcuffs in a sexual way", 1, 0));
        frases.Add(new Frases(195, "he visto crespúsculo", "watched twilight", 0, 1));
        frases.Add(new Frases(198, "he follado con los calcetines puestos", "had sex without taking my socks off", 1, 0));
        frases.Add(new Frases(199, "me ha puesto cachondo el cuerpo sudado", "made me horny the swety body", 1, 0));
        frases.Add(new Frases(200, "me ha puesto cachondo una minifalda", "made me horny a short skirt", 1, 0));
        frases.Add(new Frases(201, "me ha puesto cachondo que marquen paquete", "made me horny hard muscles", 1, 0));
        frases.Add(new Frases(207, "no he podido mear por que estaba empalmado", "couldn't peed because I was too horny", 1, 0));
        frases.Add(new Frases(208, "he tenido relaciones sexuales con alguien internacional ", "had sex with someone from another country", 1, 0));
        frases.Add(new Frases(211, "he follado en la cama de mis padres", "had sex in the bed of my parents", 1, 0));

        frases.Add(new Frases(215, "he follado con mi ex después de dejarlo", "had sex with my ex after breaking up", 1, 0));
        frases.Add(new Frases(216, "he quedado con alguien que he conocido por el Tinder or Grindr", "met someone I've met by the Tinder or Grindr", 1, 0));
        frases.Add(new Frases(217, "he follado en un ascensor", "had sex in a levator", 1, 0));
        frases.Add(new Frases(218, "he utilizado algún objeto de casa como juguete sexual", "hused any object from home as a sex toy", 1, 0));
        frases.Add(new Frases(226, "he probado semen", "swallowed cum", 1, 0));
        frases.Add(new Frases(227, "he tenido ladillas", "had crabs", 1, 0));
        frases.Add(new Frases(228, "he pillado alguna ETS", "had any ETS", 1, 0));
        frases.Add(new Frases(229, "he pensado que cuando te haces mas mayor y te hechas novio/a ya no te masturbas y estaba equivocado!", "thought that when you get older and you become a boyfriend, you do not masturbate anymore and I was wrong!", 1, 0));
        frases.Add(new Frases(230, "he orinado a alguien encima", "urinated on someone", 1, 0));
        frases.Add(new Frases(231, "he me han puesto cachondo cuando me chupan ... un pié!", "been put horny when they suck me ... one foot!", 1, 0));
        frases.Add(new Frases(232, "he follado con alguien que tenía el pene pequeño", "fucked with someone who had a small penis", 1, 0));
    }
}
