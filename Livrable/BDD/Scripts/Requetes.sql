select recette.* from recette join cdr on cdr.idCDR=recette.CDR_idCDR join commande_has_recette as cr on cr.Recette_idRecette=recette.idRecette 
where idCDR=5 
group by idRecette order by sum(cr.nbRecette)
limit 5;

select recette.nom from recette join cdr on cdr.idCDR=recette.CDR_idCDR join commande_has_recette as cr on cr.Recette_idRecette=recette.idRecette 
where idCDR=5 
group by idRecette 
having sum(cr.nbRecette)>=ALL
(select sum(cr.nbRecette) from recette join cdr on cdr.idCDR=recette.CDR_idCDR join commande_has_recette as cr on cr.Recette_idRecette=recette.idRecette 
where idCDR=5 
group by idRecette);

select recette.*,sum(cr.nbRecette) from recette join commande_has_recette as cr on cr.Recette_idRecette=recette.idRecette group by idRecette order by sum(cr.nbRecette) desc limit 5;
