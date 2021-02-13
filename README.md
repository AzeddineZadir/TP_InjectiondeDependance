# TP_InjectiondeDependance
Injection de dependance
1
Gestion de dependance sans outil
On met en place pour le logiciel de caisse d'un supermarche une classe TicketDeCaisse dont le r^ole sera de
cumuler les achats lors d'un passage en caisse, puis d'editer le ticket de caisse. Le prix des articles peut varier
en fonction du prol du client(famille nombreuse, selection de produits a prix reduits), il faut donc le charger.
On prevoit une methode getParamClient qui se charge de cette t^ache, et retourne un ParamClient. Pour
l'exemple, ParamClient est une classe qui ne contient qu'une cha^ne de caracteres. Dans getParamClient, on
doit faire appel a la classe ChargementParametres, qui a partir du numero de client, recupere le compte du
client en se connectant a un systeme central, recupere les parametres, et peut les retourner.
Dans ChargementParametres, on aura une methode permettant de recuperer un compte client, et une
methode retournant les parametres du client (on ne fera pas d'acces distant a un serveur central, sauf si vous
en avez envie, simulez cela par tout artice de votre choix).
Question 1. Mettez en place le code adequate.
On constate que la methode getParamClient doit creer une instance de ChargementParametres, et en est
donc fortement dependante. Si le constructeur de ChargementParametres change, la methode changera aussi.
Nous allons voir 3 moyens simples pour modier cette dependance : en l'injectant par mutateurs/champs,
par constructeur, et par utilisation d'interfaces.
Question 2. Pour eviter que la classe TicketDeCaisse ne soit responsable de l'instanciation de la dependance,
une solution naturelle est d'introduire un champs (attribut) et un mutateur (accesseur en ecriture) sur ce
champs. Ainsi, l'instanciation de la dependance devient a la charge de l'utilisateur de la classe TicketDeCaisse,
qui appelera le mutateur. Essayez cette solution.
Pour bien faire, il faut prendre des precautions car le mutateur peut ne pas avoir ete appele, et il nous faut
eviter les appels a de references null ... L'utilisateur doit systematiquement appeler le mutateur avant d'appeler
la methode getParmClient, ce qui est dicile a imposer et pas intuitif.
Question 3. Pour eviter que le client n'omette l'appel au mutateur, une autre facon d'injecter la dependance
est de le faire par le biais d'un constructeur : le constructeur de TicketDeCaisse requiert une instance de
ChargementParametres. Mettez en place cette solution. On remarque que l'utilisateur ne peut plus oublier de
fournir l'instance de ChargementParametres, puisqu'il en a besoin a la construction.
Question 4. La dependance est toutefois toujours presente, et en cas de changement d'implementation pour le
chargement de parametres, la classe TicketDeCaisse sera impactee. Pour limite l'impact, on peut alors utiliser
une interface, en plus de l'injection soit par mutateur, soit par constructeur. L'interface IChargementParametres
declare les methodes publiques propres au chargement de parametres, et ChargementParametres les implemente.
Dans TicketDeCaisse, on remplace les references a ChargementParametres par des references a l'interface. Testez.
On note que maintenant on a un couplage plus faible, l'implementation du chargement de parametres peut ^etre
changee sans impact sur le TicketDeCaisse.
La dependance est maintenant completement releguee vers l'utilisateur. Toutefois, l'instanciation devra bien
avoir lieu, potentiellement plusieurs fois.
2
Injection de dependance avec conteneur IOC
Pour faciliter l'utilisation de TicketCaisse par le client, on souhaite lui eviter l'instanciation directe. Ainsi
on parametre une fois que tel Client utilisera tel type de ChargementParam, et ensuite le client, quand il en a
besoin, demande au conteneur de lui donner une instance. Nous allons utiliser Ninject.
2.1
installer Ninject dans le projet
Ninject se deploie dans un projet particulier, car la version de Ninject depend de la version de .net utilisee
dans le projet.
| Sur la solution : ouvrir le menu "gerer les packages NuGet pour la solution", puis onglet parcourir, choisir
Ninject, selectionner le projet souhaite, puis valider.
2.2
fonctionnement global de Ninject
Ninject travaille a partir d'un objet de type Kernel. Dans un kernel, on peut charger des modules, ce sont
les modules qui contiennent les informations de resolution de type.
Creer un module. Un module est une classe, par exemple MonModule, qui implemente StandardModule
(ou tout autre module Ninject). StandardModule est dans le namespace Ninject.Modules. Au chargement d'un
module, sa methode public void Load() est appelee, il faut ici la redenir. A l'interieur, on fait les associations
entre une interface et une classe. Ainsi, quand le client reclamera un objet type par cette interface, Ninject
pourra retourner une instance de la classe. L'association se fait ainsi :
Bind<IBidule>().To<Bidule>();
ou Bidule implemente IBidule.
Creer un Kernel et lui associer un module :
IKernel kernel = new StandardKernel(new MonModule());
IKernel et StandardKernel sont dans le namespace Ninject.
Demander une instance au kernel : IBidule bidule = kernel.Get<IBidule>() ;
On remarque que Ninject, contrairement a d'autres conteneurs IOC, ne travaille pas via des chiers de
conguration.
2.3
Application aux tickets de caisse
| Reprenez la version avec les interfaces.
| Developpez une nouvelle implementation de IChargementParametres qui simule toujours le chargement
dse parametres.
| Creez un module capable d'associer l'une ou l'autre des implementations a IChargementParametres, en
fonction d'un parametre (booleen par exemple, ou entier ou autre).
| Creez un kernel avec le module, demandez un IChargementParametres, utilisez-le pour creer un ticket
de caisse.
| Verier que selon le parametre choisi pour creer le module, on passe d'une implementation a l'autre de
maniere totalement transparente.
3
Exemple de Martin Fowler
Question 5. Reprenez l'exemple de Martin Fowler (https ://martinfowler.com/articles/injection.html) en .net.
Question 6. Comparez les modes d'injection de Ninject (https ://github.com/ninject/Ninject/wiki/Injection-
Patterns) avec ceux exposes par Martin Fowler.
