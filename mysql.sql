-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: base
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `sys_email`
--

DROP TABLE IF EXISTS `sys_email`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_email` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '发件人邮箱号',
  `password` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '邮箱授权码',
  `isssl` int(11) DEFAULT NULL COMMENT '是否启用ssl',
  `host` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '邮件服务器地址',
  `prot` int(11) DEFAULT NULL COMMENT '端口号',
  `name` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '发件人名称',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='邮箱配置信息';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_email`
--

LOCK TABLES `sys_email` WRITE;
/*!40000 ALTER TABLE `sys_email` DISABLE KEYS */;
INSERT INTO `sys_email` VALUES (1,'输入自己邮箱','输入自己的code',1,'smtp.qq.com',465,'依然');
/*!40000 ALTER TABLE `sys_email` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_menu`
--

DROP TABLE IF EXISTS `sys_menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_menu` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `parent_id` int(11) NOT NULL COMMENT '0是一级目录 如果有儿子的话就是他的id依此类推 金字塔',
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '名称',
  `path` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '路径',
  `icon` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '图标',
  `sork` int(11) DEFAULT '1' COMMENT '排序',
  `remark` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '备注',
  `Static` int(11) DEFAULT '1' COMMENT '是否启用',
  `action` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '如果有内容的话就是操作 不显示菜单',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='菜单表	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_menu`
--

LOCK TABLES `sys_menu` WRITE;
/*!40000 ALTER TABLE `sys_menu` DISABLE KEYS */;
INSERT INTO `sys_menu` VALUES (1,0,'管理员管理','/admin/role','&#xe6b8;',1,NULL,1,'EditCategrory'),(2,1,'菜单列表','/admin/role/index','&#xe696;',22,NULL,1,''),(3,1,'权限分类','/admin/role/category',NULL,21,NULL,1,NULL),(4,3,'权限分类添加','/admin/role/addcategrory',NULL,2,NULL,1,'addcategrory'),(5,3,'权限分类删除','/admin/role/removecategrory',NULL,3,NULL,1,'removecategrory'),(6,3,'权限分类排序','/admin/role/setsork',NULL,2,NULL,1,'setsork'),(7,3,'权限分类编辑','/admin/role/editcategrory',NULL,2,NULL,1,'editcategrory'),(8,2,'菜单排序','/admin/role/setsork','&#xe696;',2,NULL,1,'setsork'),(9,2,'菜单删除','/admin/role/delete',NULL,2,NULL,1,'roledelete'),(10,2,'菜单添加','/admin/role/add',NULL,1,NULL,1,'roleadd'),(11,1,'管理员列表','/admin/role/UserIndex','',20,NULL,1,NULL),(12,1,'角色管理','/admin/role/roleindex','&#xe696;',19,NULL,1,NULL),(13,2,'菜单编辑','/admin/role/edit',NULL,1,NULL,1,'roleedit'),(14,11,'管理员编辑','/admin/role/useredit','&#xe696;',1,NULL,1,'useredit'),(15,11,'管理员删除','/admin/role/userdel','&#xe696;',1,NULL,1,'userdel'),(16,11,'管理员添加','/admin/role/useradd','&#xe696;',1,NULL,1,'useradd'),(17,12,'角色删除','/admin/role/rolesdel','&#xe696;',1,NULL,1,'rolesdel'),(18,12,'角色编辑','/admin/role/rolesedit','&#xe696;',1,NULL,1,'rolesedit'),(19,12,'角色添加','/admin/role/rolesadd','&#xe696;',1,NULL,1,'rolesadd'),(20,0,'首页管理','/admin/homepage','&#xe696;',5,NULL,1,'EditCategrory'),(21,20,'Banner管理','/admin/homepage/banner','&#xe696;',1,NULL,1,NULL),(22,21,'Banner添加','/admin/homepage/addbanner','&#xe696;',1,NULL,1,'addbanner'),(23,21,'Banner编辑','/admin/homepage/editbanner','&#xe696;',2,NULL,1,'editbanner'),(24,21,'Banner删除','/admin/homepage/delbanner','&#xe696;',2,NULL,1,'delbanner'),(25,20,'关于我们','/admin/homepage/about','&#xe696;',1,NULL,1,NULL),(26,25,'关于我们编辑','/admin/homepage/editabout','&#xe696;',1,NULL,1,'editabout'),(27,20,'技术支持','/admin/homepage/support','&#xe696;',1,NULL,1,NULL),(28,27,'技术支持删除','/admin/homepage/delsupport','&#xe696;',1,NULL,1,'delsupport'),(29,27,'技术支持编辑','/admin/homepage/editsupport','&#xe696;',1,NULL,1,'editsupport'),(30,27,'技术支持添加','/admin/homepage/addsupport','&#xe696;',1,NULL,1,'addsupport'),(31,20,'应用领域','/admin/homepage/field','&#xe696;',1,NULL,1,NULL),(32,31,'应用领域删除','/admin/homepage/delfield','&#xe696;',1,NULL,1,'delfield'),(33,31,'应用领域添加','/admin/homepage/addfield','&#xe696;',1,NULL,1,'addfield'),(34,31,'应用领域编辑','/admin/homepage/editfield','&#xe696;',1,NULL,1,'editfield'),(35,0,'加盟管理','/admin/form','&#xe69f;',4,NULL,1,'AddCategrory'),(36,35,'加盟列表','/admin/form/index','&#xe696;',1,NULL,1,NULL),(37,36,'加盟表单删除','/admin/form/delform','&#xe696;',1,NULL,1,'delform'),(38,36,'加盟表单回复','/admin/form/subform','&#xe696;',1,NULL,1,'subform'),(39,36,'加盟表单操作','/admin/form/eaitform','&#xe696;',1,NULL,1,'eaitform'),(40,0,'网站设置','/admin/web','&#xe6ae;',2,NULL,1,'AddCategrory'),(41,40,'发送邮件设置','/admin/web/setemail','&#xe696;',1,NULL,1,NULL),(42,40,'网站信息设置','/admin/web/index','&#xe696;',2,NULL,1,NULL),(43,0,'产品管理','/admin/product','&#xe6f6;',3,NULL,1,''),(44,43,'产品列表','/admin/product/index','&#xe696;',2,NULL,1,NULL),(45,44,'产品列表编辑','/admin/product/editproduct','&#xe696;',1,NULL,1,'editproduct'),(46,44,'产品列表删除','/admin/product/delproduct','&#xe696;',2,NULL,1,'delproduct'),(47,44,'产品列表添加','/admin/product/addproduct','&#xe696;',2,NULL,1,'addproduct');
/*!40000 ALTER TABLE `sys_menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_role`
--

DROP TABLE IF EXISTS `sys_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '角色名',
  `menu_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '角色拥有权限 数组',
  `addtime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '备注',
  `entity` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '标识',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='角色权限表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_role`
--

LOCK TABLES `sys_role` WRITE;
/*!40000 ALTER TABLE `sys_role` DISABLE KEYS */;
INSERT INTO `sys_role` VALUES (1,'超级管理员','','2020-08-06 18:20:05','拥有至高无上的权利','SuperAdmin'),(2,'系统管理员','20,31,32,33,34,25,26,21,24,23,22,27,29,30,28,35,36,38,39,37,43,44,46,47,45,40,42,41','2020-08-06 22:40:33','一人之下,万人之上','Admin'),(4,'运营人员','20,31,32,33,34,25,26,21,24,23,22,27,29,30,28,35,36,38,39,37,43,44,46,47,45','2020-08-13 17:35:41','产品管理员',NULL);
/*!40000 ALTER TABLE `sys_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_user`
--

DROP TABLE IF EXISTS `sys_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键 guid形式',
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '用户名',
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '密码 加密格式MD5',
  `addtime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '昵称',
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '备注',
  `role_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '角色id 数组形式',
  `Static` int(11) DEFAULT NULL COMMENT '状态',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='后台管理员列表	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_user`
--

LOCK TABLES `sys_user` WRITE;
/*!40000 ALTER TABLE `sys_user` DISABLE KEYS */;
INSERT INTO `sys_user` VALUES (1,'root','ff9830c42660c1dd1942844f8069b74a','2020-08-06 18:19:36','root','超级管理员','1',1),(2,'admin','0192023a7bbd73250516f069df18b500','2020-08-10 16:11:23','admin','普通管理员','2,4',1),(4,'test','cc03e747a6afbbcbf8be7668acfebee5','2020-08-13 13:10:41','test','	文章管理员','4',1);
/*!40000 ALTER TABLE `sys_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_about`
--

DROP TABLE IF EXISTS `yr_about`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_about` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cn_title` varchar(45) DEFAULT NULL COMMENT '中文标题',
  `en_title` varchar(45) DEFAULT NULL COMMENT '英文标题',
  `content` text COMMENT '富文本内容',
  `update_time` datetime DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='关于我们';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_about`
--

LOCK TABLES `yr_about` WRITE;
/*!40000 ALTER TABLE `yr_about` DISABLE KEYS */;
INSERT INTO `yr_about` VALUES (1,'关于我们','About Us','<p>							</p><p style=\"text-align: center;\"><font color=\"#333333\">这是富文本自己想写什么写什么</font></p><p>							</p><p style=\"text-align: center\"><img src=\"/ueupload/6373330682154570991518665.jpg\" alt=\"6373330682154570991518665.jpg\"/></p><p>							</p><p><strong style=\"font-size: 20px;\"><span style=\"color: rgb(51, 51, 51);\">背景介绍：</span></strong><br/></p><p>							</p><p style=\"text-indent: 2em;margin-top: 10px;\"><font color=\"#333333\">我没有背景，小老百姓不要欺负俺</font></p>','2020-08-21 20:18:36');
/*!40000 ALTER TABLE `yr_about` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_banner`
--

DROP TABLE IF EXISTS `yr_banner`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_banner` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `image` varchar(255) DEFAULT NULL COMMENT '图片地址',
  `href` varchar(255) DEFAULT NULL COMMENT '图片外联',
  `addtime` datetime DEFAULT CURRENT_TIMESTAMP,
  `type` int(11) DEFAULT NULL COMMENT '1:pc 2:m',
  `remark` varchar(45) DEFAULT NULL COMMENT '备注',
  `Static` int(11) DEFAULT '1' COMMENT '是否启用',
  `sork` int(11) DEFAULT '1' COMMENT '排序 数值越大排序越高',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='banner图	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_banner`
--

LOCK TABLES `yr_banner` WRITE;
/*!40000 ALTER TABLE `yr_banner` DISABLE KEYS */;
INSERT INTO `yr_banner` VALUES (1,'/upload/20200821bf3c422bff3a4f039321b64dcd45d980.jpg','http://www.baidu.com','2020-08-15 19:32:36',1,'测试PCbanner',1,122),(2,'/upload/20200821463aafb5f8da4a7d8759eaf5b1a797e2.jpg','http://www.baidu.com','2020-08-15 19:32:37',2,'测试Mbanner',1,1);
/*!40000 ALTER TABLE `yr_banner` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_common`
--

DROP TABLE IF EXISTS `yr_common`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_common` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '唯一id就一条',
  `logo` varchar(255) DEFAULT NULL COMMENT 'logo图片地址',
  `phone` varchar(22) DEFAULT NULL COMMENT '联系电话',
  `qq` varchar(22) DEFAULT NULL COMMENT 'qq号码',
  `wechat` varchar(255) DEFAULT NULL COMMENT '微信二维码图片地址',
  `copy` varchar(66) DEFAULT NULL COMMENT '版权信息',
  `beian` varchar(45) DEFAULT NULL COMMENT '备案号',
  `remark` varchar(45) DEFAULT NULL COMMENT '备注',
  `update_time` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `description` varchar(255) DEFAULT NULL COMMENT 'SEO',
  `keywords` varchar(255) DEFAULT NULL COMMENT 'SEO',
  `title` varchar(255) DEFAULT NULL COMMENT '网站标题',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='网站设置公共信息';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_common`
--

LOCK TABLES `yr_common` WRITE;
/*!40000 ALTER TABLE `yr_common` DISABLE KEYS */;
INSERT INTO `yr_common` VALUES (1,'/upload/202008215fde0c3b180941408e8e162daf9e8d47.png','13111111111','10001','/upload/202008212ca637d269f84a3a8e161bb1273e3e60.jpg','版权所有：依然','填自己的备案号',NULL,'2020-08-21 03:59:23','description','keywords','网站标题');
/*!40000 ALTER TABLE `yr_common` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_field`
--

DROP TABLE IF EXISTS `yr_field`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_field` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cn_title` varchar(45) DEFAULT NULL,
  `en_title` varchar(45) DEFAULT NULL,
  `content` varchar(255) DEFAULT NULL COMMENT '内容',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='应用领域';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_field`
--

LOCK TABLES `yr_field` WRITE;
/*!40000 ALTER TABLE `yr_field` DISABLE KEYS */;
INSERT INTO `yr_field` VALUES (1,'应用领域','Application field','应用于：\n各大网络平台，包括啥都没有');
/*!40000 ALTER TABLE `yr_field` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_field_li`
--

DROP TABLE IF EXISTS `yr_field_li`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_field_li` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `image` varchar(255) DEFAULT NULL COMMENT '图片地址',
  `title` varchar(45) DEFAULT NULL COMMENT '标题',
  `href` varchar(45) DEFAULT NULL COMMENT '外链',
  `Static` int(11) DEFAULT '1' COMMENT '是否启用',
  `addtime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `sork` int(11) DEFAULT '1' COMMENT '排序',
  `remark` varchar(45) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='应用领域列表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_field_li`
--

LOCK TABLES `yr_field_li` WRITE;
/*!40000 ALTER TABLE `yr_field_li` DISABLE KEYS */;
INSERT INTO `yr_field_li` VALUES (1,'/upload/202008216c8f5772ded241e5ba5a75e6606a719b.jpg','办公场所',NULL,1,'2020-08-18 12:22:48',33,NULL),(2,'/upload/20200821f6b496b0b6bd44f59c41029ca521e97c.jpg','商业综合体',NULL,1,'2020-08-18 12:22:48',12,NULL),(3,'/upload/202008216f654c7f31a64fdd936d344f1620cd86.jpg','医疗机构',NULL,1,'2020-08-18 12:22:48',11,NULL),(4,'/upload/20200821568717ec11d54bcf93d76890dbd2bec1.jpg','交通站点',NULL,1,'2020-08-18 12:22:48',13,NULL);
/*!40000 ALTER TABLE `yr_field_li` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_form`
--

DROP TABLE IF EXISTS `yr_form`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_form` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL COMMENT '姓名',
  `phone` varchar(45) DEFAULT NULL COMMENT '手机',
  `ress` varchar(99) DEFAULT NULL COMMENT '地址',
  `email` varchar(45) DEFAULT NULL COMMENT '邮箱',
  `msg` varchar(45) DEFAULT NULL COMMENT '留言内容',
  `addtime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `Static` int(11) DEFAULT NULL COMMENT '状态0、未查看.1、已查看，未回复.2、已经完成和回复',
  `remark` varchar(255) DEFAULT NULL COMMENT '那个管理员进行的操作',
  `remark_user` int(11) DEFAULT NULL COMMENT '操作者的用户id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='加盟表单';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_form`
--

LOCK TABLES `yr_form` WRITE;
/*!40000 ALTER TABLE `yr_form` DISABLE KEYS */;
INSERT INTO `yr_form` VALUES (8,'测试','13111111111','测试地址','10000001@qq.com','留言了','2020-08-21 22:42:48',0,NULL,NULL);
/*!40000 ALTER TABLE `yr_form` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_prouduct`
--

DROP TABLE IF EXISTS `yr_prouduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_prouduct` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cn_title` varchar(45) DEFAULT NULL COMMENT '中文标题',
  `en_title` varchar(45) DEFAULT NULL COMMENT '英文标题',
  `content` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='产品介绍';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_prouduct`
--

LOCK TABLES `yr_prouduct` WRITE;
/*!40000 ALTER TABLE `yr_prouduct` DISABLE KEYS */;
INSERT INTO `yr_prouduct` VALUES (1,'产品介绍','Prouduct Introduction','产品介绍内容\n产品介绍内容\n产品介绍内容');
/*!40000 ALTER TABLE `yr_prouduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_prouduct_list`
--

DROP TABLE IF EXISTS `yr_prouduct_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_prouduct_list` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `images` varchar(255) DEFAULT NULL COMMENT '图片多张',
  `title` varchar(45) DEFAULT NULL COMMENT '标题',
  `people_number` int(11) DEFAULT '0' COMMENT '访问人数',
  `qq` varchar(45) DEFAULT NULL COMMENT '联系号码',
  `content` text COMMENT '富文本',
  `addtime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `remark` varchar(45) DEFAULT NULL COMMENT '备注',
  `Static` int(11) DEFAULT NULL COMMENT '是否上架',
  `sork` int(11) DEFAULT '1' COMMENT '排序',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='产品列表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_prouduct_list`
--

LOCK TABLES `yr_prouduct_list` WRITE;
/*!40000 ALTER TABLE `yr_prouduct_list` DISABLE KEYS */;
INSERT INTO `yr_prouduct_list` VALUES (1,'/upload/202008214d1a40c3d4ed4062b322f6e5d39ee2a5.jpg,/upload/20200821cd71e340d7e147eeb13d174616e837fc.jpg','产品001',25,'239559238','<p>这是富文本编辑器可以放图片 放视频</p><p style=\"text-align: center;\"><img src=\"/ueupload/6373364352198869963376691.jpg\" title=\"img7.jpg\" alt=\"img7.jpg\"/></p>','2020-08-15 23:56:31',NULL,1,2);
/*!40000 ALTER TABLE `yr_prouduct_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_support`
--

DROP TABLE IF EXISTS `yr_support`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_support` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cn_title` varchar(45) DEFAULT NULL COMMENT '中文标题',
  `en_title` varchar(45) DEFAULT NULL COMMENT '英文标题',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='技术支持';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_support`
--

LOCK TABLES `yr_support` WRITE;
/*!40000 ALTER TABLE `yr_support` DISABLE KEYS */;
INSERT INTO `yr_support` VALUES (1,'技术支持','Technical support');
/*!40000 ALTER TABLE `yr_support` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yr_support_list`
--

DROP TABLE IF EXISTS `yr_support_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yr_support_list` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `icon` varchar(255) DEFAULT NULL COMMENT '图标',
  `title` varchar(45) DEFAULT NULL COMMENT '标题',
  `content` varchar(255) DEFAULT NULL COMMENT '内容',
  `addtime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `remark` varchar(45) DEFAULT NULL,
  `Static` int(11) DEFAULT '1' COMMENT '是否展示',
  `sork` int(11) DEFAULT '1' COMMENT '排序',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='技术支持列表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yr_support_list`
--

LOCK TABLES `yr_support_list` WRITE;
/*!40000 ALTER TABLE `yr_support_list` DISABLE KEYS */;
INSERT INTO `yr_support_list` VALUES (1,'/upload/2020082104cc14c22e3741beb509d665d297a41a.png','在线帮助','远程给予设备帮助','2020-08-21 22:37:25',NULL,1,133),(2,'/upload/2020082190418e1eaffe475ca3c8eed20a10b39d.png','快速开发','给您想不到的速度','2020-08-21 22:37:29',NULL,1,1),(3,'/upload/20200821680e504bd6494f5c8a3c10363524ece1.png','安全系统','系统安全性可靠','2020-08-21 22:37:34',NULL,1,1),(5,'/upload/20200821e1a55f0badb147bd9b612fca62c3b6eb.png','也没什么好扯的','自己写自己想写的吧','2020-08-21 22:37:38',NULL,1,1);
/*!40000 ALTER TABLE `yr_support_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'base'
--

--
-- Dumping routines for database 'base'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-08-21 22:50:14
