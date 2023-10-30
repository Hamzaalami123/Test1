Pour exécuter l'image Dockerfile en local, procédez comme suit :

1 - Installez d'abord Docker sur votre machine.
Ensuite, utilisez les commandes suivantes pour construire et exécuter l'image Docker :

2 - Construisez l'image Docker en utilisant la commande suivante :

> docker build -t projettest1

3 - Exécutez l'image Docker en utilisant la commande suivante pour mapper le port 8080 de votre machine au port 80 de l'image :

> docker run -p 8080:80 projettest1


