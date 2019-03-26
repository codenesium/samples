import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpecialOfferMapper from '../specialOffer/specialOfferMapper';
import SpecialOfferViewModel from '../specialOffer/specialOfferViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SpecialOfferTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface SpecialOfferTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SpecialOfferViewModel>;
}

export class SpecialOfferTableComponent extends React.Component<
  SpecialOfferTableComponentProps,
  SpecialOfferTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SpecialOfferViewModel) {
    this.props.history.push(
      ClientRoutes.SpecialOffers + '/edit/' + row.specialOfferID
    );
  }

  handleDetailClick(e: any, row: SpecialOfferViewModel) {
    this.props.history.push(
      ClientRoutes.SpecialOffers + '/' + row.specialOfferID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.SpecialOfferClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SpecialOfferMapper();

        let specialOffers: Array<SpecialOfferViewModel> = [];

        response.data.forEach(x => {
          specialOffers.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: specialOffers,
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
                Header: 'SpecialOffers',
                columns: [
                  {
                    Header: 'Category',
                    accessor: 'category',
                    Cell: props => {
                      return <span>{String(props.original.category)}</span>;
                    },
                  },
                  {
                    Header: 'Description',
                    accessor: 'description',
                    Cell: props => {
                      return <span>{String(props.original.description)}</span>;
                    },
                  },
                  {
                    Header: 'Discount Pct',
                    accessor: 'discountPct',
                    Cell: props => {
                      return <span>{String(props.original.discountPct)}</span>;
                    },
                  },
                  {
                    Header: 'End Date',
                    accessor: 'endDate',
                    Cell: props => {
                      return <span>{String(props.original.endDate)}</span>;
                    },
                  },
                  {
                    Header: 'Max Qty',
                    accessor: 'maxQty',
                    Cell: props => {
                      return <span>{String(props.original.maxQty)}</span>;
                    },
                  },
                  {
                    Header: 'Min Qty',
                    accessor: 'minQty',
                    Cell: props => {
                      return <span>{String(props.original.minQty)}</span>;
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
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
                    },
                  },
                  {
                    Header: 'Start Date',
                    accessor: 'startDate',
                    Cell: props => {
                      return <span>{String(props.original.startDate)}</span>;
                    },
                  },
                  {
                    Header: 'Type',
                    accessor: 'reservedType',
                    Cell: props => {
                      return <span>{String(props.original.reservedType)}</span>;
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
                              row.original as SpecialOfferViewModel
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
                              row.original as SpecialOfferViewModel
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
    <Hash>c27945bba2866ef96173ce04caccdb3e</Hash>
</Codenesium>*/