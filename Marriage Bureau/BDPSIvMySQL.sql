/*==============================================================*/
/* DBMS name:      MySQL 4.0                                    */
/* Created on:     30/12/2016 19:31:30                          */
/*==============================================================*/



/*==============================================================*/
/* Table: CARACTERISTICASPESSOAIS                               */
/*==============================================================*/
create table CARACTERISTICASPESSOAIS
(
   IDCPESSOAIS                    int                            not null AUTO_INCREMENT,
   COROLHOS                       int                            not null,
   ETNIA                          int                            not null,
   CORCABELO                      int                            not null,
   ALTURA                         int                            not null,
   PROFISSAO                      varchar(100)                   not null,
   CORPREFERIDA                   varchar(100)                   not null,
   QUERFILHOS                     bool                           not null,
   TEMANIMAIS                     bool                           not null,
   ESTILOVIDA                     varchar(100)                   not null,
   TRACOSCARACTERISTICOS          varchar(100)                   not null,
   DEFEITOS                       varchar(100)                   not null,
   ESTILOMUSICA                   varchar(100)                   not null,
   IDOLOS                         varchar(100)                   not null,
   FILMESFAVORITOS                varchar(100)                   not null,
   primary key (IDCPESSOAIS)
)
engine = InnoDB;

/*==============================================================*/
/* Table: ENCONTRO                                              */
/*==============================================================*/
create table ENCONTRO
(
   IDENCONTRO                     int                            not null AUTO_INCREMENT,
   IDPASSO                        int                            not null,
   IDPESSOA                       int                            not null,
   PES_IDPESSOA                   int                            not null,
   LUGAR                          varchar(100)                   not null,
   DATAENCONTRO                   datetime                       not null,
   FEEDBACKPORENCONTRO            varchar(500),
   primary key (IDENCONTRO, IDPASSO)
)
engine = InnoDB;

/*==============================================================*/
/* Index: ENCONTRO_PESSOA_FK                                    */
/*==============================================================*/
create index ENCONTRO_PESSOA_FK on ENCONTRO
(
   PES_IDPESSOA
);

/*==============================================================*/
/* Index: ENC_PESSOA2_FK                                        */
/*==============================================================*/
create index ENC_PESSOA2_FK on ENCONTRO
(
   IDPESSOA
);

/*==============================================================*/
/* Table: NOTIFICACOES                                          */
/*==============================================================*/
create table NOTIFICACOES
(
   IDNOTIFICACOES                 int                            not null AUTO_INCREMENT,
   USERNAME                       varchar(50)                    not null,
   TEMPO                          datetime,
   DESCRICAO                      varchar(140),
   VISTA                          bool,
   primary key (IDNOTIFICACOES)
)
engine = InnoDB;

/*==============================================================*/
/* Index: UTILIZADOR_NOTIFICACOES_FK                            */
/*==============================================================*/
create index UTILIZADOR_NOTIFICACOES_FK on NOTIFICACOES
(
   USERNAME
);

/*==============================================================*/
/* Table: PASSATEMPOS                                           */
/*==============================================================*/
create table PASSATEMPOS
(
   IDTEMPOSLIVRES                 int                            not null AUTO_INCREMENT,
   TEMPOSLIVRES                   varchar(100)                   not null,
   primary key (IDTEMPOSLIVRES)
)
engine = InnoDB;

/*==============================================================*/
/* Table: PESSOA                                                */
/*==============================================================*/
create table PESSOA
(
   IDPESSOA                       int                            not null AUTO_INCREMENT,
   USERNAME                       varchar(50)                    not null,
   QUERGUARDAR                    bool                           not null,
   NOMECOMPLETO                   varchar(250)                   not null,
   SEXO                           bool                           not null,
   IDADE                          int                            not null,
   ALTURA                         int                            not null,
   MORADA                         varchar(250)                   not null,
   FOTOPERFIL                     varchar(250)                   not null,
   FOTOCC                         varchar(250)                   not null,
   FEEDBACKAPP                    varchar(500),
   primary key (IDPESSOA)
)
engine = InnoDB;

/*==============================================================*/
/* Index: PESSOA_UTILIZADOR_FK                                  */
/*==============================================================*/
create index PESSOA_UTILIZADOR_FK on PESSOA
(
   USERNAME
);

/*==============================================================*/
/* Table: PROCURAC                                              */
/*==============================================================*/
create table PROCURAC
(
   IDPESSOA                       int                            not null,
   IDCPESSOAIS                    int                            not null,
   primary key (IDPESSOA, IDCPESSOAIS)
)
engine = InnoDB;

/*==============================================================*/
/* Index: PROCURAC_FK                                           */
/*==============================================================*/
create index PROCURAC_FK on PROCURAC
(
   IDPESSOA
);

/*==============================================================*/
/* Index: PROCURAC2_FK                                          */
/*==============================================================*/
create index PROCURAC2_FK on PROCURAC
(
   IDCPESSOAIS
);

/*==============================================================*/
/* Table: PROCURAP                                              */
/*==============================================================*/
create table PROCURAP
(
   IDPESSOA                       int                            not null,
   IDTEMPOSLIVRES                 int                            not null,
   primary key (IDPESSOA, IDTEMPOSLIVRES)
)
engine = InnoDB;

/*==============================================================*/
/* Index: PROCURAP_FK                                           */
/*==============================================================*/
create index PROCURAP_FK on PROCURAP
(
   IDPESSOA
);

/*==============================================================*/
/* Index: PROCURAP2_FK                                          */
/*==============================================================*/
create index PROCURAP2_FK on PROCURAP
(
   IDTEMPOSLIVRES
);

/*==============================================================*/
/* Table: TEMC                                                  */
/*==============================================================*/
create table TEMC
(
   IDPESSOA                       int                            not null,
   IDCPESSOAIS                    int                            not null,
   primary key (IDPESSOA, IDCPESSOAIS)
)
engine = InnoDB;

/*==============================================================*/
/* Index: TEMC_FK                                               */
/*==============================================================*/
create index TEMC_FK on TEMC
(
   IDPESSOA
);

/*==============================================================*/
/* Index: TEMC2_FK                                              */
/*==============================================================*/
create index TEMC2_FK on TEMC
(
   IDCPESSOAIS
);

/*==============================================================*/
/* Table: TEMP                                                  */
/*==============================================================*/
create table TEMP
(
   IDPESSOA                       int                            not null,
   IDTEMPOSLIVRES                 int                            not null,
   primary key (IDPESSOA, IDTEMPOSLIVRES)
)
engine = InnoDB;

/*==============================================================*/
/* Index: TEMP_FK                                               */
/*==============================================================*/
create index TEMP_FK on TEMP
(
   IDPESSOA
);

/*==============================================================*/
/* Index: TEMP2_FK                                              */
/*==============================================================*/
create index TEMP2_FK on TEMP
(
   IDTEMPOSLIVRES
);

/*==============================================================*/
/* Table: UTILIZADOR                                            */
/*==============================================================*/
create table UTILIZADOR
(
   USERNAME                       varchar(50)                    not null,
   PASSWORD                       varchar(50)                    not null,
   primary key (USERNAME)
)
engine = InnoDB;

alter table ENCONTRO add constraint FK_ENCONTRO_PESSOA foreign key (PES_IDPESSOA)
      references PESSOA (IDPESSOA) on delete restrict on update restrict;

alter table ENCONTRO add constraint FK_ENC_PESSOA2 foreign key (IDPESSOA)
      references PESSOA (IDPESSOA) on delete restrict on update restrict;

alter table NOTIFICACOES add constraint FK_UTILIZADOR_NOTIFICACOES foreign key (USERNAME)
      references UTILIZADOR (USERNAME) on delete restrict on update restrict;

alter table PESSOA add constraint FK_PESSOA_UTILIZADOR foreign key (USERNAME)
      references UTILIZADOR (USERNAME) on delete restrict on update restrict;

alter table PROCURAC add constraint FK_PROCURAC foreign key (IDPESSOA)
      references PESSOA (IDPESSOA) on delete restrict on update restrict;

alter table PROCURAC add constraint FK_PROCURAC2 foreign key (IDCPESSOAIS)
      references CARACTERISTICASPESSOAIS (IDCPESSOAIS) on delete restrict on update restrict;

alter table PROCURAP add constraint FK_PROCURAP foreign key (IDPESSOA)
      references PESSOA (IDPESSOA) on delete restrict on update restrict;

alter table PROCURAP add constraint FK_PROCURAP2 foreign key (IDTEMPOSLIVRES)
      references PASSATEMPOS (IDTEMPOSLIVRES) on delete restrict on update restrict;

alter table TEMC add constraint FK_TEMC foreign key (IDPESSOA)
      references PESSOA (IDPESSOA) on delete restrict on update restrict;

alter table TEMC add constraint FK_TEMC2 foreign key (IDCPESSOAIS)
      references CARACTERISTICASPESSOAIS (IDCPESSOAIS) on delete restrict on update restrict;

alter table TEMP add constraint FK_TEMP foreign key (IDPESSOA)
      references PESSOA (IDPESSOA) on delete restrict on update restrict;

alter table TEMP add constraint FK_TEMP2 foreign key (IDTEMPOSLIVRES)
      references PASSATEMPOS (IDTEMPOSLIVRES) on delete restrict on update restrict;

