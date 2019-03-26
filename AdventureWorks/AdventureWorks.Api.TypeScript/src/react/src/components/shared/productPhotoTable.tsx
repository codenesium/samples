import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProductPhotoMapper from '../productPhoto/productPhotoMapper';
import ProductPhotoViewModel from '../productPhoto/productPhotoViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductPhotoTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface ProductPhotoTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ProductPhotoViewModel>;
}

export class ProductPhotoTableComponent extends React.Component<
  ProductPhotoTableComponentProps,
  ProductPhotoTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: ProductPhotoViewModel) {
    this.props.history.push(
      ClientRoutes.ProductPhotoes + '/edit/' + row.productPhotoID
    );
  }

  handleDetailClick(e: any, row: ProductPhotoViewModel) {
    this.props.history.push(
      ClientRoutes.ProductPhotoes + '/' + row.productPhotoID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.ProductPhotoClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductPhotoMapper();

        let productPhotoes: Array<ProductPhotoViewModel> = [];

        response.data.forEach(x => {
          productPhotoes.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: productPhotoes,
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
                Header: 'ProductPhotoes',
                columns: [
                  {
                    Header: 'Large Photo',
                    accessor: 'largePhoto',
                    Cell: props => {
                      return <span>{String(props.original.largePhoto)}</span>;
                    },
                  },
                  {
                    Header: 'Large Photo File Name',
                    accessor: 'largePhotoFileName',
                    Cell: props => {
                      return (
                        <span>{String(props.original.largePhotoFileName)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Thumb Nail Photo',
                    accessor: 'thumbNailPhoto',
                    Cell: props => {
                      return (
                        <span>{String(props.original.thumbNailPhoto)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Thumbnail Photo File Name',
                    accessor: 'thumbnailPhotoFileName',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.thumbnailPhotoFileName)}
                        </span>
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
                              row.original as ProductPhotoViewModel
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
                              row.original as ProductPhotoViewModel
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
    <Hash>3b6b8c16e0b7406a409f2961561d37b9</Hash>
</Codenesium>*/