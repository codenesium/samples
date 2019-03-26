import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductProductPhotoMapper from '../productProductPhoto/productProductPhotoMapper';
import ProductProductPhotoViewModel from '../productProductPhoto/productProductPhotoViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductProductPhotoTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface ProductProductPhotoTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ProductProductPhotoViewModel>;
}

export class ProductProductPhotoTableComponent extends React.Component<
  ProductProductPhotoTableComponentProps,
  ProductProductPhotoTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ProductProductPhotoViewModel) {
    this.props.history.push(
      ClientRoutes.ProductProductPhotoes + '/edit/' + row.productID
    );
  }

  handleDetailClick(e: any, row: ProductProductPhotoViewModel) {
    this.props.history.push(
      ClientRoutes.ProductProductPhotoes + '/' + row.productID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.ProductProductPhotoClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductProductPhotoMapper();

        let productProductPhotoes: Array<ProductProductPhotoViewModel> = [];

        response.data.forEach(x => {
          productProductPhotoes.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: productProductPhotoes,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
                Header: 'ProductProductPhotoes',
                columns: [
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Primary',
                    accessor: 'primary',
                    Cell: props => {
                      return <span>{String(props.original.primary)}</span>;
                    },
                  },
                  {
                    Header: 'Product I D',
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
                            props.original.productIDNavigation &&
                              props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Product Photo I D',
                    accessor: 'productPhotoID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.ProductPhotoes +
                                '/' +
                                props.original.productPhotoID
                            );
                          }}
                        >
                          {String(
                            props.original.productPhotoIDNavigation &&
                              props.original.productPhotoIDNavigation.toDisplay()
                          )}
                        </a>
                      );
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
                              row.original as ProductProductPhotoViewModel
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
                              row.original as ProductProductPhotoViewModel
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
    <Hash>e2afb25569905642d3cbf95727bde7e6</Hash>
</Codenesium>*/