import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductReviewMapper from '../productReview/productReviewMapper';
import ProductReviewViewModel from '../productReview/productReviewViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface ProductReviewTableComponentProps {
  productReviewID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface ProductReviewTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ProductReviewViewModel>;
}

export class ProductReviewTableComponent extends React.Component<
  ProductReviewTableComponentProps,
  ProductReviewTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ProductReviewViewModel) {
    this.props.history.push(ClientRoutes.ProductReviews + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: ProductReviewViewModel) {
    this.props.history.push(ClientRoutes.ProductReviews + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.ProductReviewClientResponseModel
          >;

          console.log(response);

          let mapper = new ProductReviewMapper();

          let productReviews: Array<ProductReviewViewModel> = [];

          response.forEach(x => {
            productReviews.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: productReviews,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'ProductReviews',
                columns: [
                  {
                    Header: 'Comments',
                    accessor: 'comment',
                    Cell: props => {
                      return <span>{String(props.original.comment)}</span>;
                    },
                  },
                  {
                    Header: 'EmailAddress',
                    accessor: 'emailAddress',
                    Cell: props => {
                      return <span>{String(props.original.emailAddress)}</span>;
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'ProductID',
                    accessor: 'productID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Products +
                                '/' +
                                props.original.productID
                            );
                          }}
                        >
                          {String(
                            props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'ProductReviewID',
                    accessor: 'productReviewID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.productReviewID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Rating',
                    accessor: 'rating',
                    Cell: props => {
                      return <span>{String(props.original.rating)}</span>;
                    },
                  },
                  {
                    Header: 'ReviewDate',
                    accessor: 'reviewDate',
                    Cell: props => {
                      return <span>{String(props.original.reviewDate)}</span>;
                    },
                  },
                  {
                    Header: 'ReviewerName',
                    accessor: 'reviewerName',
                    Cell: props => {
                      return <span>{String(props.original.reviewerName)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as ProductReviewViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as ProductReviewViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>b1a01e2c1cd0a2322521e43ad1919df8</Hash>
</Codenesium>*/