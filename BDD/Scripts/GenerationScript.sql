-- MySQL Script generated by MySQL Workbench
-- Tue Apr 28 17:39:46 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Cook
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Cook
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Cook` DEFAULT CHARACTER SET utf8 ;
USE `Cook` ;

-- -----------------------------------------------------
-- Table `Cook`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Client` (
  `idClient` INT NOT NULL AUTO_INCREMENT,
  `NumeroTel` VARCHAR(10) NOT NULL,
  `Nom` VARCHAR(45) NOT NULL,
  `Prenom` VARCHAR(45) NOT NULL,
  `Adresse` VARCHAR(100) NOT NULL,
  `Mdp` VARCHAR(50) NOT NULL,
  `Pseudo` VARCHAR(45) NOT NULL,
  `AdrMail` VARCHAR(100) NULL,
  `Sexe` CHAR(1) NOT NULL,
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `NumeroTel_UNIQUE` (`NumeroTel` ASC) VISIBLE,
  UNIQUE INDEX `idClient_UNIQUE` (`idClient` ASC) VISIBLE,
  UNIQUE INDEX `Pseudo_UNIQUE` (`Pseudo` ASC) VISIBLE,
  UNIQUE INDEX `AdrMail_UNIQUE` (`AdrMail` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`Commande`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Commande` (
  `idCommande` INT NOT NULL AUTO_INCREMENT,
  `Date` DATE NOT NULL,
  `Montant` DOUBLE NOT NULL,
  `Client_idClient` INT NOT NULL,
  PRIMARY KEY (`idCommande`),
  UNIQUE INDEX `idCommande_UNIQUE` (`idCommande` ASC) VISIBLE,
  INDEX `fk_Commande_Client1_idx` (`Client_idClient` ASC) VISIBLE,
  CONSTRAINT `fk_Commande_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `Cook`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`CDR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`CDR` (
  `idCDR` INT NOT NULL AUTO_INCREMENT,
  `Solde` DOUBLE NULL DEFAULT 0,
  `Client_idClient` INT NOT NULL,
  PRIMARY KEY (`idCDR`),
  UNIQUE INDEX `idCDR_UNIQUE` (`idCDR` ASC) VISIBLE,
  INDEX `fk_CDR_Client1_idx` (`Client_idClient` ASC) VISIBLE,
  CONSTRAINT `fk_CDR_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `Cook`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`Fournisseur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Fournisseur` (
  `idFournisseur` INT NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NOT NULL,
  `NumeroTel` VARCHAR(10) NOT NULL,
  `DateCommande` DATE NULL,
  PRIMARY KEY (`idFournisseur`),
  UNIQUE INDEX `idFournisseur_UNIQUE` (`idFournisseur` ASC) VISIBLE,
  UNIQUE INDEX `Nom_UNIQUE` (`Nom` ASC) VISIBLE,
  UNIQUE INDEX `NumeroTel_UNIQUE` (`NumeroTel` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`Produit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Produit` (
  `idProduit` INT NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NOT NULL,
  `Categorie` VARCHAR(45) NOT NULL,
  `Unite` VARCHAR(5) NOT NULL,
  `StockMin` DOUBLE NULL DEFAULT 0,
  `StockMax` DOUBLE NULL DEFAULT 0,
  `StockActuel` DOUBLE NULL DEFAULT 0,
  `Fournisseur_idFournisseur` INT NOT NULL,
  `DateUpdate` DATE NULL,
  PRIMARY KEY (`idProduit`, `Fournisseur_idFournisseur`),
  UNIQUE INDEX `idProduit_UNIQUE` (`idProduit` ASC) VISIBLE,
  INDEX `fk_Produit_Fournisseur1_idx` (`Fournisseur_idFournisseur` ASC) VISIBLE,
  CONSTRAINT `fk_Produit_Fournisseur1`
    FOREIGN KEY (`Fournisseur_idFournisseur`)
    REFERENCES `Cook`.`Fournisseur` (`idFournisseur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`Recette`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Recette` (
  `idRecette` INT NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NOT NULL,
  `Description` MEDIUMTEXT NOT NULL,
  `Prix` DOUBLE NOT NULL,
  `url` VARCHAR(200) NULL,
  `Type` VARCHAR(45) NOT NULL,
  `CDR_idCDR` INT NULL,
  PRIMARY KEY (`idRecette`),
  UNIQUE INDEX `idRecette_UNIQUE` (`idRecette` ASC) VISIBLE,
  UNIQUE INDEX `Nom_UNIQUE` (`Nom` ASC) VISIBLE,
  INDEX `fk_Recette_CDR1_idx` (`CDR_idCDR` ASC) VISIBLE,
  CONSTRAINT `fk_Recette_CDR1`
    FOREIGN KEY (`CDR_idCDR`)
    REFERENCES `Cook`.`CDR` (`idCDR`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`Recette_has_Produit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Recette_has_Produit` (
  `Recette_idRecette` INT NOT NULL,
  `Produit_idProduit` INT NOT NULL,
  `Quantite` DOUBLE NOT NULL,
  PRIMARY KEY (`Recette_idRecette`, `Produit_idProduit`),
  INDEX `fk_Recette_has_Produit_Produit1_idx` (`Produit_idProduit` ASC) VISIBLE,
  INDEX `fk_Recette_has_Produit_Recette_idx` (`Recette_idRecette` ASC) VISIBLE,
  CONSTRAINT `fk_Recette_has_Produit_Recette`
    FOREIGN KEY (`Recette_idRecette`)
    REFERENCES `Cook`.`Recette` (`idRecette`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Recette_has_Produit_Produit1`
    FOREIGN KEY (`Produit_idProduit`)
    REFERENCES `Cook`.`Produit` (`idProduit`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`Commande_has_Recette`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Commande_has_Recette` (
  `Commande_idCommande` INT NOT NULL,
  `Recette_idRecette` INT NOT NULL,
  `nbRecette` INT NULL,
  PRIMARY KEY (`Commande_idCommande`, `Recette_idRecette`),
  INDEX `fk_Commande_has_Recette_Recette1_idx` (`Recette_idRecette` ASC) VISIBLE,
  INDEX `fk_Commande_has_Recette_Commande1_idx` (`Commande_idCommande` ASC) VISIBLE,
  CONSTRAINT `fk_Commande_has_Recette_Commande1`
    FOREIGN KEY (`Commande_idCommande`)
    REFERENCES `Cook`.`Commande` (`idCommande`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Commande_has_Recette_Recette1`
    FOREIGN KEY (`Recette_idRecette`)
    REFERENCES `Cook`.`Recette` (`idRecette`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cook`.`Gestionnaire`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Cook`.`Gestionnaire` (
  `idGestionnaire` VARCHAR(45) NOT NULL,
  `Mdp` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idGestionnaire`))
ENGINE = InnoDB;

USE `Cook`;

DELIMITER $$
USE `Cook`$$
CREATE DEFINER = CURRENT_USER TRIGGER `Cook`.`Commande_has_Recette_BEFORE_INSERT` BEFORE INSERT ON `Commande_has_Recette` FOR EACH ROW
BEGIN

	DECLARE nTot INT;
	SELECT sum(nbRecette) 
	INTO nTot 
	FROM commande_has_recette 
	WHERE Recette_idRecette=new.Recette_idRecette;
    
    IF nTot is null THEN
		SET nTot=0;
	END IF;

	IF nTot<10 and nTot+new.nbRecette>=10 THEN
		UPDATE recette
		SET Prix = Prix+2
		WHERE idRecette=new.Recette_idRecette;
	END IF;
		
	IF nTot<50 and nTot+new.nbRecette>=50 THEN
		UPDATE recette
		SET Prix = Prix+5
		WHERE idRecette=new.Recette_idRecette;
	END IF;
    

END$$

USE `Cook`$$
CREATE DEFINER = CURRENT_USER TRIGGER `Cook`.`Commande_has_Recette_BEFORE_INSERT_1` BEFORE INSERT ON `Commande_has_Recette` FOR EACH ROW
BEGIN

	DECLARE nTot INT;
    DECLARE idCDR_recette INT;
    
	SELECT sum(nbRecette) 
	INTO nTot 
	FROM Commande_has_Recette 
	WHERE Recette_idRecette=new.Recette_idRecette;
    
    SELECT CDR_idCDR 
    INTO idCDR_recette
    FROM Recette
    WHERE idRecette=new.Recette_idRecette;
    
    IF nTot is null THEN
		SET nTot=0;
	END IF;
	
    IF nTot<50 and nTot+new.nbRecette>=50 THEN
		UPDATE CDR SET Solde=Solde+(nTot+new.nbRecette-49)*4 WHERE idCDR=idCDR_recette;
		
	END IF;
    IF nTot>=50 THEN
		UPDATE CDR SET Solde=Solde+new.nbRecette*4 WHERE idCDR=idCDR_recette;
       
	END IF;

END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
