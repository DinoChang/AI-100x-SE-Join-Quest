@bulk_discount
Feature: Bulk Discount Promotion
  As a shopper
  I want to receive a 20% discount when purchasing 10 or more of the same product
  So that I can save money when buying in bulk

  Background:
    Given the bulk discount promotion is active with:
      | minimumQuantity | discountPercentage |
      | 10              | 20                |

  Scenario: Purchase 12 pieces of the same product - partial bulk discount
    When a customer places an order with:
      | productName | quantity | unitPrice |
      | 襪子          | 12       | 100       |
    Then the order summary should be:
      | totalAmount |
      | 1000        |
    And the discount calculation should be:
      | quantity | unitPrice | discountedQuantity | originalQuantity | discountedAmount | originalAmount | totalAmount |
      | 12       | 100       | 10                 | 2                | 800              | 200            | 1000        |

  Scenario: Purchase 27 pieces of the same product - multiple bulk discounts
    When a customer places an order with:
      | productName | quantity | unitPrice |
      | 襪子          | 27       | 100       |
    Then the order summary should be:
      | totalAmount |
      | 2300        |
    And the discount calculation should be:
      | quantity | unitPrice | discountedQuantity | originalQuantity | discountedAmount | originalAmount | totalAmount |
      | 27       | 100       | 20                 | 7                | 1600             | 700            | 2300        |

  Scenario: Purchase 10 different products - no bulk discount applied
    When a customer places an order with:
      | productName | quantity | unitPrice |
      | 商品A         | 1        | 100       |
      | 商品B         | 1        | 100       |
      | 商品C         | 1        | 100       |
      | 商品D         | 1        | 100       |
      | 商品E         | 1        | 100       |
      | 商品F         | 1        | 100       |
      | 商品G         | 1        | 100       |
      | 商品H         | 1        | 100       |
      | 商品I         | 1        | 100       |
      | 商品J         | 1        | 100       |
    Then the order summary should be:
      | totalAmount |
      | 1000        |
    And no bulk discount should be applied because the products are different

  Scenario: Purchase exactly 10 pieces of the same product - full bulk discount
    When a customer places an order with:
      | productName | quantity | unitPrice |
      | 襪子          | 10       | 100       |
    Then the order summary should be:
      | totalAmount |
      | 800         |
    And the discount calculation should be:
      | quantity | unitPrice | discountedQuantity | originalQuantity | discountedAmount | originalAmount | totalAmount |
      | 10       | 100       | 10                 | 0                | 800              | 0              | 800         |

  Scenario: Mixed products with one qualifying for bulk discount
    When a customer places an order with:
      | productName | quantity | unitPrice |
      | 襪子          | 15       | 100       |
      | T-shirt     | 3        | 200       |
    Then the order summary should be:
      | totalAmount |
      | 1900        |
    And the discount calculation should be:
      | productName | quantity | unitPrice | discountedQuantity | originalQuantity | discountedAmount | originalAmount |
      | 襪子          | 15       | 100       | 10                 | 5                | 800              | 500            |
      | T-shirt     | 3        | 200       | 0                  | 3                | 0                | 600            |