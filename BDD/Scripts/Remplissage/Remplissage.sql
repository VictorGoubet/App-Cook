
-- INSERTION CLIENTS
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0784585682,"Clotou","Didier","50 Rue des Montagnes","D78;:;r","Did80","did.clot@yahoo.fr",'M');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0652525576,"Delavigne","Léa","1 Route du Soleil","9er4/","Clozette","delavignelea@orange.fr",'F');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0655554554,"Aubertier","Salomé","26 Boulevard de la Fite","iuefusefz","Salome","aubertier.salome@orange.fr",'F');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0785325655,"Aglout","Paul","4 Impasse des Tréas","Aglou75","Polo","PaulAgl25@gmail.fr",'M');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0782522502,"Monfia","Estelle","12 rue Montro","!!Es2599","Monfiette","Monfia.estelle@hotmail.com",'F');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0705124256,"Traberdo","Emma","1 rue du Breil","&&jo&&15","Em","Emmatraberdo@gmail.com",'F');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0653202562,"Glofu","Frederic","50 ru du Coudray","heymdp!","Fred","Fredou85@orange.fr",'M');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0652414777,"Faraday","Adrien","3bis de la route des Cygnes","ierj27Ol","_Adri70","AdriFard@edu.devinci.fr",'M');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0679985869,"Monfot","Agathe","5 route de la vigne","8518449H","-Ag-","Agathe.monfot@wanadoo.fr",'F');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0784774523,"Hubert","Alice","85 rue Victo Hugo","r8874zere","Alouille","Alice85@yopmail.com",'F');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0672557379,"Goubet","Victor","34 rue Jules Verne","mdp","vico","victor.goubet@edu.devinci.fr",'M');
insert into client (NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values (0669696969,"Graff","Thomas","88 rue des chomeurs","mdp","toto","graff.thomas@edu.devinci.fr",'M');


-- INSERTION CDR

insert into cdr (Client_idClient) values(2);
insert into cdr (Client_idClient) values(4);
insert into cdr (Client_idClient) values(5);
insert into cdr (Client_idClient) values(11);
insert into cdr (Client_idClient) values(12);

-- INSERTION RECETTES

insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Poulet au curry","Le poulet au curry est un plat originaire du sous-continent indien. C'est une délicatesse commune dans le sous-continent indien, en Asie du Sud-Est, en Grande-Bretagne ainsi qu'aux Caraïbes.",14.99,"https://assets.afcdn.com/recipe/20160405/6932_w648h414c1cx2125cy1414.jpg","Plat",1);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Moules-Frites","Les moules-frites sont un mets très populaire en Belgique et dans le nord de la France, constitué de moules cuites et accompagnées de frites. ",16.75,"https://sf1.viepratique.fr/wp-content/uploads/sites/2/2014/02/shutterstock_115952584.jpg","Plat",3);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Brownie","Le brownie est un gâteau au chocolat, fondant par endroits, cuit au four. Un glaçage peut être ensuite déposé sur sa surface. Sa crème de préparation peut également être mangée sans être cuite.",4,"https://www.academiedugout.fr/images/11875/1200-686/brownie-chocolat.jpg?poix=50&poiy=50","Dessert",2);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Omelette Provencale","L'omelette est un plat à base d'œufs. Elle est à la fois très simple et très rapide à réaliser, que ce soit au niveau de la préparation, des ingrédients ajoutés ou de la cuisson. ",9.99,"https://img.mesrecettesfaciles.fr/wp-content/uploads/2017/05/omelette-provenc%CC%A7ale-1000x500.jpg","Plat",1);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Gaspacho","Le gaspacho est un potage à base de légumes crus mixés servi froid, très répandu dans le sud de l'Espagne et le sud du Portugal.",8.50,"https://assets.afcdn.com/recipe/20140812/22701_w1024h768c1cx1881cy1325.jpg","Entrée",1);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Steack Tartare","Le steak tartare ou tartare est une recette à base de viande de bœuf ou de viande de cheval crue, généralement hachée gros, ou coupée en petits cubes au couteau.",14.50,"https://img.cuisineaz.com/680x357/2019-04-28/i146754-steak-tartare-parfait.jpeg","Entrée",3);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Kougelhopf","Le kougelhopf, de son nom originel alsacien, ou encore kouglof, kougelhof, kugelhof, kugelopf, kugelhopf ou kouglouf est une spécialité alsacienne, de l'Autriche, de la République tchèque et du sud de l'Allemagne.",7,"https://www.cookomix.com/wp-content/uploads/2017/07/kougelhopf-thermomix-800x600.jpg","Dessert",4);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Sushis","Le sushi (寿司?) est un plat traditionnel japonais, composé d'un riz vinaigré appelé shari (舎利?) combiné avec un autre ingrédient appelé neta (寿司ネタ?) qui est habituellement du poisson cru ou des fruits de mer. ",16,"https://static.lexpress.fr/medias_12020/w_2048,h_1146,c_crop,x_0,y_154/w_480,h_270,c_fill,g_north/v1550742170/sushi-saumon-maki-saumon-japonais_6154396.jpg","Plat",5);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Flammekueche","La tarte flambée ou Flammekueche est une recette traditionnelle des cuisine alsacienne, cuisine lorraine de la Moselle germanophone, et de la cuisine allemande des régions adjacentes du Pays de Bade, du Palatinat.",12.99,"https://cache.marieclaire.fr/data/photo/w1000_ci/1bj/flammekueche.jpg","Plat",1);
insert into recette (Nom,Description,Prix,url,Type,CDR_idCDR) values("Bruschetta","Une bruschetta [brus'ketːta] est une préparation culinaire traditionnelle d'antipasti typique de la cuisine italienne.",7.50,"https://www.sanpellegrinofruitbeverages.com/ch/sites/g/files/xknfdk866/files/bruschetta_h_17.jpg","Entrée",2);

-- INSERTION FOURNISSEURS

insert into fournisseur(Nom,NumeroTel) values ("ViandOMax","0258569853");
insert into fournisseur(Nom,NumeroTel) values ("PatoNouille","0485695327");
insert into fournisseur(Nom,NumeroTel) values ("ChezCoucourgette","0958547412");
insert into fournisseur(Nom,NumeroTel) values ("BaraThon","0485652537");
insert into fournisseur(Nom,NumeroTel) values ("Boitameuhhh","0356874129");
insert into fournisseur(Nom,NumeroTel) values ("Surcotcotcoté","0987562312");
insert into fournisseur(Nom,NumeroTel) values ("Boulangeou","0245857965");
insert into fournisseur(Nom,NumeroTel) values ("SpiceX","0584569832");
insert into fournisseur(Nom,NumeroTel) values ("Obonpinar","0158745869");
insert into fournisseur(Nom,NumeroTel) values ("SaucageParty","0240560571");

-- INSERTION PRODUITS

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Poulet","Viande","Kg",0,100,0,6);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Curry","Epice","g",0,1000,0,8);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Cumin","Epice","g",0,1000,0,8);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Piment","Epice","g",0,1000,0,8);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Poivre","Epice","g",0,1000,0,8);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Sel","Epice","g",0,1000,0,8);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Crème fraiche","Produit Laitier","cL",0,1000,0,5);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Oignons","Légume","",0,50,0,3);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Moules","Poissons","Kg",0,60,0,4);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Pomme de terre","Légume","Kg",0,200,0,3);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Echalotte","Légume","",0,40,0,3);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Ail","Légume","",0,30,0,3);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Vin blanc","Alcool","cL",0,2000,0,9);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Beurre","Produit Laitier","Kg",0,250,0,5);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Oeuf","Autre","",0,150,0,6);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Farine","Autre","Kg",0,50,0,7);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Sucre","Autre","Kg",0,50,0,7);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Chocolat","Autre","Kg",0,5,0,7);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Persil","Herbe aromatique","g",0,500,0,3);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Poivron","Légume","",0,50,0,3);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Tomates","Légume","",0,50,0,3);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Concombre","Légume","",0,15,0,3);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Basilic","Herbe aromatique","g",0,300,0,3);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Pain de mie","Pain","Kg",0,5,0,7);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Viande hachée","viande","Kg",0,50,0,1);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Ketchup","Sauce","cL",0,500,0,10);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Tabasco","Sauce","cL",0,100,0,10);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Moutarde","Sauce","cL",0,100,0,10);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Capre","Légume","g",0,400,0,3);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Lait","Produit Laitier","L",0,100,0,5);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Levure","Autre","g",0,100,0,7);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Sucre glace","Autre","Kg",0,5,0,7);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Riz à sushi","Féculent","Kg",0,6,0,2);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Saumon","Poisson","Kg",0,5,0,4);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Wazabi","Sauce","cL",0,50,0,10);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Vinaigre de riz","Vinaigre","cL",0,500,0,9);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Lardons","viande","Kg",0,15,0,1);

insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Pain de campagne","Pain","Kg",0,10,0,7);
insert into produit(Nom,Categorie,Unite,StockMin,StockMax,StockActuel,Fournisseur_idFournisseur) values ("Mozarella","Produit Laitier","g",0,1000,0,5);


-- INSERTION PRODUITS/RECETTES

insert into recette_has_produit values (1,1);
insert into recette_has_produit values (1,2);
insert into recette_has_produit values (1,3);
insert into recette_has_produit values (1,4);
insert into recette_has_produit values (1,5);
insert into recette_has_produit values (1,6);
insert into recette_has_produit values (1,7);
insert into recette_has_produit values (1,8);

insert into recette_has_produit values (2,9);
insert into recette_has_produit values (2,10);
insert into recette_has_produit values (2,11);
insert into recette_has_produit values (2,12);
insert into recette_has_produit values (2,13);
insert into recette_has_produit values (2,14);
insert into recette_has_produit values (2,8);
insert into recette_has_produit values (2,19);

insert into recette_has_produit values (3,15);
insert into recette_has_produit values (3,16);
insert into recette_has_produit values (3,17);
insert into recette_has_produit values (3,18);
insert into recette_has_produit values (3,8);
insert into recette_has_produit values (3,6);

insert into recette_has_produit values (4,19);
insert into recette_has_produit values (4,20);
insert into recette_has_produit values (4,15);
insert into recette_has_produit values (4,8);
insert into recette_has_produit values (4,21);
insert into recette_has_produit values (4,5);
insert into recette_has_produit values (4,6);

insert into recette_has_produit values (5,21);
insert into recette_has_produit values (5,22);
insert into recette_has_produit values (5,23);
insert into recette_has_produit values (5,24);
insert into recette_has_produit values (5,5);
insert into recette_has_produit values (5,6);
insert into recette_has_produit values (5,5);
insert into recette_has_produit values (5,8);
insert into recette_has_produit values (5,15);
insert into recette_has_produit values (5,12);

insert into recette_has_produit values (6,25);
insert into recette_has_produit values (6,26);
insert into recette_has_produit values (6,27);
insert into recette_has_produit values (6,28);
insert into recette_has_produit values (6,29);
insert into recette_has_produit values (6,5);
insert into recette_has_produit values (6,6);
insert into recette_has_produit values (6,8);
insert into recette_has_produit values (6,15);

insert into recette_has_produit values (7,30);
insert into recette_has_produit values (7,31);
insert into recette_has_produit values (7,32);
insert into recette_has_produit values (7,14);
insert into recette_has_produit values (7,15);
insert into recette_has_produit values (7,6);

insert into recette_has_produit values (8,33);
insert into recette_has_produit values (8,34);
insert into recette_has_produit values (8,35);
insert into recette_has_produit values (8,36);

insert into recette_has_produit values (9,8);
insert into recette_has_produit values (9,7);
insert into recette_has_produit values (9,37);
insert into recette_has_produit values (9,6);
insert into recette_has_produit values (9,16);

insert into recette_has_produit values (10,38);
insert into recette_has_produit values (10,39);
insert into recette_has_produit values (10,21);
insert into recette_has_produit values (10,23);
insert into recette_has_produit values (10,6);
insert into recette_has_produit values (10,12);






