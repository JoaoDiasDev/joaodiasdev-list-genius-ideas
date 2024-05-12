CREATE TABLE IF NOT EXISTS `products_list` (
  `id` BIGINT(11) AUTO_INCREMENT PRIMARY KEY,
  `name` VARCHAR(255) NOT NULL,
  `description` VARCHAR(255) NOT NULL,
  `image` BLOB NOT NULL,
  `enabled` BOOLEAN DEFAULT TRUE NOT NULL,
  `public` BOOLEAN DEFAULT FALSE NOT NULL,
  `total_products_count` INT NOT NULL,
  `total_products_value` DECIMAL(65,2) NOT NULL,
  `external_link` VARCHAR(255) NOT NULL,
  `created_date` DATETIME(6) NOT NULL,
  `updated_date` DATETIME(6) NOT NULL,
  `id_users` BIGINT(11) NOT NULL,
  FOREIGN KEY (`id_users`) REFERENCES `users`(`id`),
  UNIQUE `name` (`name`),
  UNIQUE `external_link` (`external_link`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
