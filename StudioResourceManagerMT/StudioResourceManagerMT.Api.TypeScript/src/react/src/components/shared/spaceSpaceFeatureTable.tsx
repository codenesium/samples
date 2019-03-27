import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpaceSpaceFeatureMapper from '../spaceSpaceFeature/spaceSpaceFeatureMapper';
import SpaceSpaceFeatureViewModel from '../spaceSpaceFeature/spaceSpaceFeatureViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface SpaceSpaceFeatureTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface SpaceSpaceFeatureTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SpaceSpaceFeatureViewModel>;
}

export class SpaceSpaceFeatureTableComponent extends React.Component<
  SpaceSpaceFeatureTableComponentProps,
  SpaceSpaceFeatureTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SpaceSpaceFeatureViewModel) {
    this.props.history.push(
      ClientRoutes.SpaceSpaceFeatures + '/edit/' + row.spaceId
    );
  }

  handleDetailClick(e: any, row: SpaceSpaceFeatureViewModel) {
    this.props.history.push(
      ClientRoutes.SpaceSpaceFeatures + '/' + row.spaceId
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.SpaceSpaceFeatureClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SpaceSpaceFeatureMapper();

        let spaceSpaceFeatures: Array<SpaceSpaceFeatureViewModel> = [];

        response.data.forEach(x => {
          spaceSpaceFeatures.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: spaceSpaceFeatures,
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
                Header: 'SpaceSpaceFeatures',
                columns: [
                  {
                    Header: 'Space Feature',
                    accessor: 'spaceFeatureId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.SpaceFeatures +
                                '/' +
                                props.original.spaceFeatureId
                            );
                          }}
                        >
                          {String(
                            props.original.spaceFeatureIdNavigation &&
                              props.original.spaceFeatureIdNavigation.toDisplay()
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
                              row.original as SpaceSpaceFeatureViewModel
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
                              row.original as SpaceSpaceFeatureViewModel
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
    <Hash>de12d3b477295ddd9d3522ca697cc60b</Hash>
</Codenesium>*/