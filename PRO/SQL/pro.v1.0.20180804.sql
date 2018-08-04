/*
SQLyog Ultimate v12.09 (64 bit)
MySQL - 5.7.13-log : Database - pro
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pro` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `pro`;

/*Table structure for table `t_db` */

DROP TABLE IF EXISTS `t_db`;

CREATE TABLE `t_db` (
  `db_ip` varchar(45) NOT NULL COMMENT '数据库IP',
  `db_user` varchar(45) NOT NULL COMMENT '数据库用户名',
  `db_pass` varchar(45) NOT NULL COMMENT '数据库密码',
  `db_port` varchar(45) NOT NULL COMMENT '数据库端口'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_db` */

insert  into `t_db`(`db_ip`,`db_user`,`db_pass`,`db_port`) values ('127.0.0.1','root','123456','3306');

/*Table structure for table `t_pro` */

DROP TABLE IF EXISTS `t_pro`;

CREATE TABLE `t_pro` (
  `idx` int(11) NOT NULL COMMENT '主键',
  `date` varchar(45) DEFAULT NULL COMMENT '订单日期',
  `machine_num` varchar(45) DEFAULT NULL COMMENT '机器编码',
  `company` varchar(45) DEFAULT NULL COMMENT '公司',
  `client` varchar(45) DEFAULT NULL COMMENT '客户名称',
  `type_num` varchar(45) DEFAULT NULL COMMENT '型号',
  `goods` varchar(200) DEFAULT NULL COMMENT '发出货物',
  `total` int(11) DEFAULT NULL COMMENT '总金额',
  `subcompany` varchar(45) DEFAULT NULL COMMENT '分公司金额',
  `receivables` varchar(45) DEFAULT NULL COMMENT '收款情况',
  `address` varchar(200) DEFAULT NULL COMMENT '客户地址',
  `book_date` varchar(45) DEFAULT NULL COMMENT '接单日期',
  `send_date` varchar(45) DEFAULT NULL COMMENT '发货日期',
  `arrival_date` varchar(45) DEFAULT NULL COMMENT '到货日期',
  `ship_num` int(11) DEFAULT NULL COMMENT '发货件数',
  `ship_state` varchar(45) DEFAULT NULL COMMENT '发货状态，未发货；已发货',
  `logistics` varchar(45) DEFAULT NULL COMMENT '物流',
  `freight` varchar(45) DEFAULT NULL COMMENT '运费',
  `trans_num` varchar(45) DEFAULT NULL COMMENT '运输单号',
  `tel` varchar(45) DEFAULT NULL COMMENT '查询电话',
  `note` varchar(45) DEFAULT NULL COMMENT '备注',
  `type` varchar(45) DEFAULT NULL COMMENT '订单类型，保养；新购',
  `bill_need` varchar(45) DEFAULT NULL COMMENT '订单需求，否；是',
  `bill_state` varchar(45) DEFAULT NULL COMMENT '开票状态，未开具,已开具',
  `area` varchar(45) DEFAULT NULL COMMENT '地区',
  `remind` varchar(45) DEFAULT '未取消提醒' COMMENT '提醒状态,未提醒，已提醒，不需要提醒',
  `debt` varchar(8) DEFAULT NULL COMMENT '是否欠款',
  `debtM` varchar(45) DEFAULT NULL COMMENT '欠款数额',
  PRIMARY KEY (`idx`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_pro` */

insert  into `t_pro`(`idx`,`date`,`machine_num`,`company`,`client`,`type_num`,`goods`,`total`,`subcompany`,`receivables`,`address`,`book_date`,`send_date`,`arrival_date`,`ship_num`,`ship_state`,`logistics`,`freight`,`trans_num`,`tel`,`note`,`type`,`bill_need`,`bill_state`,`area`,`remind`,`debt`,`debtM`) values (1531554744,'2018年7月14日','111','asdfsafds','asdfsdf','123','sdafsd',12324,'123412','sdfsd','asdfa','2018年7月14日','2018年7月14日','2018年7月14日',23,'运输中1','sadfa','234','12212','3423','asdfasdfa','123','是','未开具','四川省','是','',''),(1531557086,'2018年7月4日','028123','成都瑞鑫','宜宾韵达','50A','50冷干机，空调A型604',45002,'34800','招行转账','宜宾市江安区3号街208室','2018年7月5日','2018年7月6日','2018年7月12日',2,'','德邦物流','2300','1234567653','028-83006521','12sdafsd','保养','是','未开具','上海市','未取消提醒','',''),(1532221982,'2018年7月22日','222','2123dsd','dfsafasd','50A','221e',12321,'2321','现金','sdfasdf','2018年7月22日','2018年7月22日','2018年7月22日',3,'','asdf','23423','232321213','2132','12321','新购','是','未开具','北京市','未取消提醒','',''),(1532750788,'2018年7月28日','2018072801','重庆大名科技','张大明，西南大明','A50','A50设备，附属相关设备',250000,'200000','招商银行','重庆市朝天门测试A区','2018年7月28日','2018年7月28日','2018年8月4日',4,'已发货','德邦','1500','2018209231','10086','需要发货','保养','是','未开具','重庆市','未取消提醒','是','2000');

/*Table structure for table `t_test` */

DROP TABLE IF EXISTS `t_test`;

CREATE TABLE `t_test` (
  `idx` int(11) NOT NULL,
  `test` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idx`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_test` */

/*Table structure for table `t_user` */

DROP TABLE IF EXISTS `t_user`;

CREATE TABLE `t_user` (
  `user_id` int(11) NOT NULL COMMENT '用户ID',
  `user_name` varchar(45) NOT NULL COMMENT '登录用户名',
  `user_pass` varchar(45) NOT NULL COMMENT '登录密码',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_user` */

insert  into `t_user`(`user_id`,`user_name`,`user_pass`) values (1,'admin','123');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
