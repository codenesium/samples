import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VendorMapper from '../vendor/vendorMapper';
import VendorViewModel from '../vendor/vendorViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface VendorTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface VendorTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<VendorViewModel>;
}

export class VendorTableComponent extends React.Component<
  VendorTableComponentProps,
  VendorTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: VendorViewModel) {
    this.props.history.push(
      ClientRoutes.Vendors + '/edit/' + row.businessEntityID
    );
  }

  handleDetailClick(e: any, row: VendorViewModel) {
    this.props.history.push(ClientRoutes.Vendors + '/' + row.businessEntityID);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.VendorClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VendorMapper();

        let vendors: Array<VendorViewModel> = [];

        response.data.forEach(x => {
          vendors.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: vendors,
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
                Header: 'Vendors',
                columns: [
                  {
                    Header: 'Account Number',
                    accessor: 'accountNumber',
                    Cell: props => {
                      return (
                        <span>{String(props.original.accountNumber)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Active Flag',
                    accessor: 'activeFlag',
                    Cell: props => {
                      return <span>{String(props.original.activeFlag)}</span>;
                    },
                  },
                  {
                    Header: 'Credit Rating',
                    accessor: 'creditRating',
                    Cell: props => {
                      return <span>{String(props.original.creditRating)}</span>;
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
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
                    },
                  },
                  {
                    Header: 'Preferred Vendor Status',
                    accessor: 'preferredVendorStatu',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.preferredVendorStatu)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Purchasing Web Service U R L',
                    accessor: 'purchasingWebServiceURL',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.purchasingWebServiceURL)}
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
                              row.original as VendorViewModel
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
                              row.original as VendorViewModel
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
    <Hash>581ec6319b5b581a765b06f51bdcaff8</Hash>
</Codenesium>*/