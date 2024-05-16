CREATE TABLE IF NOT EXISTS `shared_products`(
	`id` BIGINT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`name` VARCHAR(255) NOT NULL,
	`value` DECIMAL(65,2) NOT NULL,
	`description` VARCHAR(255) NOT NULL,
	`qrcode` VARCHAR(255) NOT NULL,
	`image`  BLOB NOT NULL,
	`link` VARCHAR(255) NOT NULL,
	`enabled` BOOLEAN DEFAULT TRUE NOT NULL,
	`created_date` DATETIME(6) NOT NULL,
	`updated_date` DATETIME(6) NOT NULL,
	`unit` ENUM('Unspecified', 'Meter', 'SquareMeter', 'CubicMeter', 'Unit') NOT NULL,
	`id_groups` BIGINT(11) NOT NULL,
	`id_sub_groups` BIGINT(11) NOT NULL,
	FOREIGN KEY (`id_groups`) REFERENCES `groups`(`id`),
	FOREIGN KEY (`id_sub_groups`) REFERENCES `sub_groups`(`id`),
	UNIQUE `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;